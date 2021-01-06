# IRF_Project

## Introduction

  This program is a project to be submitted to Budapest Corvinus University.
  It can help to create simple moving average from data lists, which are stored in CSV files.

## Main features

### Open CSV files

This Menu item can import a CSV file from the file system. It loads the file and fill the left part of the window as a data table.

### Save Diagram to PNG

The result diagram, with the original chart and the moving averages can be saved into the file system as PNG file.

### Settings

In this menu item we can choose the X and the Y axis from the CSV file columns, or the helper **Items** column.
We can define the title of the axis, the color and the legend of the main line as well.
Moving averages can be defined here, maximum 5.
We can choose the number of the points in moving average, the legend of the average and the color of the line.
Please take care about the number: it should be bigger, than 2, and smaller than half of the rows!

### Generate Chart

This button starts the diagram generation. First time, when we just still opened the CSV file, the Settings dialog will appear.
Later, we can ask a regeneration with this button, after changing settings in _Settings_ Dialog.

### Help

It contains a similar description about the program like this.

## Bugs

In some cases, after changing the settings, after clicking on _Generate Chart_ the lines will be invisible.

## To Do

* It would be nice to calculate _trending_ also
* Saving images to another format than PNG
* Using other data source, like Excel, Access tables, databases etc.
* More testing