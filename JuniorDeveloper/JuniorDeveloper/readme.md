# NetSupport Junior Developer Interview Exercise

## Introduction
This exercise is designed to help us ensure you're a good fit for our team. You can use the internet to find solutions to any issues you may encounter. Please be aware that we will discuss your project with you during your in-person interview so be sure to fully understand your code.

We don't expect it to take your more than 1 hour. Please don't spend more than 2 hours on the tasks.

Please try your best to relax and have fun with this task! :)

## Overview
This application uses .Net 7 and Entity Framework Core. It is a simple API that allows you to create, update and delete users and groups. Users can be part of a group.

You're not expected to know how to configure EF Core but you will need to write some queries using it. You should be able to google for the required queries if you're not familiar with the product.

## Tasks
The following tasks are available for you to complete within this exercise. You should complete as many of the tasks as possible within the time frame.

Throughout the exercise, feel free to make any other improvements you can think of that would be appropriate.

While making changes to the code we would advise that you add comments to everything you change explaining why you decided to make that update. This will help us understand your thought process and discuss your changes with you more easily.

We would also advise saving a copy of the exercise when you've completed the required tasks so that you can avoid any issues if you decide to make other changes. If you're using a GitHub repo then you could make a commit for each task after making the changes.

### Group Service
The group service provides functionality to the application for interacting with a user group.

1. There is a bug when trying to get a specific group. Can you find and fix it.
2. There is a bug when adding a new group. A group's name should be unique but this is currently not being enforced. Can you make it so it's not possible to create a group with a name that is already in use?
3. Update the group service to use asynchronous code wherever possible.

### User Service
The user service provides functionality to the application for interacting with a user.

1. Implement the user service methods. The interface has been defined for you, you just need to complete the method implementations.

## Testing Your Changes
We have added a set of sample data to the database by default. This is so that you can run the project and see the APIs in action before starting.

> We have added an API endpoint that you can use if you need to reset the data in your database back to the original example data we provided. You can call the `/api/helper/resetDemoData` endpoint whenever you need to do this. Be aware that running this will delete ALL data from the database including anything you have added.

To run the project, make sure that the `Web.Api` project is set as the startup project in Visual Studio and then click the Run button (green play icon on the top toolbar).

Once running the project should automatically load a browser window for you and show you the swagger documentation page for the API endpoints within the exercise. You can use this page to execute example calls to the API when performing any tests.

## What Will We Look For
We will use the swagger tools explained above to test if the API is working so it's worth you double checking your work before submitting back to us.

We will read through your code and get a sense of how you work. Be sure to include comments to help us understand your decisions.

## How to Submit the Exercise
We don't mind how you submit this exercise back to us, either add it to a zip file and send it back via email, add it to OneDrive and share a link with us or upload it to GitHub into a private repository (and send us the link) so we can see it.
