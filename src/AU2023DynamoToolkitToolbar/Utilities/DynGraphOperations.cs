using Autodesk.DesignScript.Runtime;
using Dynamo.Models;
using Dynamo.ViewModels;
using Dynamo.Wpf.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Media;

namespace AU2023DynamoToolkitToolbar.Utilities;
internal class DynGraphOperations : GraphOperations
{
    private readonly string _boilerPlate;
    protected ViewLoadedParams ViewLoadedParams { get; set; }

    internal DynGraphOperations(ViewLoadedParams document)
    {
        var assembly = Assembly.GetExecutingAssembly();
        ViewLoadedParams = document;
    }

    public override void TemplatiseGraph()
    {
        DynamoViewModel dynamoViewModel = ViewLoadedParams.DynamoWindow.DataContext as DynamoViewModel;

        double minX = 0;
        double minY = 0;
        var annotationViewModels = dynamoViewModel.CurrentSpaceViewModel.Annotations;

        //Create new GUID for new notes and group elements and store for selection
        Guid guidInfo = Guid.NewGuid();
        Guid guidDescription = Guid.NewGuid();
        Guid guidInstruction = Guid.NewGuid();
        Guid guidIssues = Guid.NewGuid();
        Guid guidIdeas = Guid.NewGuid();
        Guid guidInfoGroup = Guid.NewGuid();

        //Add GUID's to list for cross-referencing
        List<Guid> notes = new List<Guid> { guidInfo, guidDescription, guidInstruction, guidIssues, guidIdeas, guidIdeas };

        var nodeIfo = new DynamoModel.CreateNoteCommand(guidInfo, GraphStandards.GraphInfo, minX - 950, minY, false);
        var nodeDescription = new DynamoModel.CreateNoteCommand(guidDescription, GraphStandards.Description, minX - 700, minY, false);
        var nodeInstructions = new DynamoModel.CreateNoteCommand(guidInstruction, GraphStandards.Instructions, minX - 450, minY, false);
        var nodeIssues = new DynamoModel.CreateNoteCommand(guidIssues, GraphStandards.Issues, minX - 700, minY + 144, false);
        var nodeIdeas = new DynamoModel.CreateNoteCommand(guidIdeas, GraphStandards.Ideas, minX - 450, minY + 144, false);

        dynamoViewModel.ExecuteCommand(nodeIfo);
        dynamoViewModel.ExecuteCommand(nodeDescription);
        dynamoViewModel.ExecuteCommand(nodeInstructions);
        dynamoViewModel.ExecuteCommand(nodeIssues);
        dynamoViewModel.ExecuteCommand(nodeIdeas);

        var groupCommand = new DynamoModel.CreateAnnotationCommand(guidInfoGroup, GraphStandards.GroupTitle, minX - 700, minY + 72, true);
        dynamoViewModel.ExecuteCommand(groupCommand);

        foreach (AnnotationViewModel group in annotationViewModels)
        {
            if (group.AnnotationModel.GUID == guidInfoGroup)
            {
                group.Background = Color.FromRgb(
                    GraphStandards.ColorTemplateGroup.R, 
                    GraphStandards.ColorTemplateGroup.B, 
                    GraphStandards.ColorTemplateGroup.G);
                foreach (var note in dynamoViewModel.Model.CurrentWorkspace.Notes)
                {
                    if (notes.Contains(note.GUID))
                    {
                        group.AnnotationModel.Nodes = group.AnnotationModel.Nodes.Append(note);
                    }
                }
            }
        }

        //Ensure window is switched to Graph View Navigation
        if (dynamoViewModel.CurrentSpaceViewModel.DynamoViewModel.BackgroundPreviewViewModel.CanNavigateBackground == true)
        { dynamoViewModel.CurrentSpaceViewModel.DynamoViewModel.BackgroundPreviewViewModel.CanNavigateBackground = false; }
    }


    public override void CreateGroup(GroupType groupName, byte red, byte green, byte blue)
    {
        var dynamoViewModel = ViewLoadedParams.DynamoWindow.DataContext as DynamoViewModel;
        var nodes = dynamoViewModel.Model.CurrentWorkspace.Nodes.Where(node => node.IsSelected).ToList();
        var groups = dynamoViewModel.CurrentSpaceViewModel.Annotations
            .Where(annotation => annotation.Nodes.Any(node => node.IsSelected)).ToList();

        if (!groups.Any() && !nodes.Any())
        {
            CustomMessages.Warning(CustomMessages.Group(groupName.ToString()));
            return;
        }

        if (groups.Any())
        {
            foreach (var group in groups)
            {
                foreach (var node in group.Nodes)
                {
                    node.Deselect();
                    if (node.IsSelected) node.Dispose();
                    nodes.Append(node);
                }

                var deleteGroup = new DynamoModel.DeleteModelCommand(group.AnnotationModel.GUID);
                dynamoViewModel.ExecuteCommand(deleteGroup);
            }
        }

        Guid groupGuid = Guid.NewGuid();

        var command = new DynamoModel.CreateAnnotationCommand(groupGuid, groupName.ToString(), 0, 0, true);
        dynamoViewModel.ExecuteCommand(command);

        var newGroup = dynamoViewModel.CurrentSpaceViewModel.Annotations.First(annotation => annotation.AnnotationModel.GUID == groupGuid);
        newGroup.Background = Color.FromRgb(red, green, blue);
        newGroup.AnnotationModel.Nodes = nodes;
    }
}
