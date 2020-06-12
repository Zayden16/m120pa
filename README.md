# Table of Contents:
* [Description](#description)  
* [GloBoard](#globoard)
* [Styleguide](#styleguide)
* [Arbeitsjournal](#arbeitsjournal)
* [Mockups](#mockups)  
    * [LoginView](#loginview)
    * [MainView](#mainview)
    * [CarsView](#carsview)
    * [UsersVIew](#usersview)
    * [InfoView](#infoview)

# Description:
This repo is intended to serve as the center of this Project. All Code and Documentation will be checked in here. User Stories and Tasks will be tracked in GitKraken GloBoards. Security is not a concern here so all Passwords will be saved as plaintext.

# GloBoard:
Progress can be tracked at any time on the GloBoard linked here: https://app.gitkraken.com/glo/board/XseLUHpYPQARN_-e
Userstories and other important tasks are documented here

# Styleguide:
Main Color: ![#673ab7](https://via.placeholder.com/15/673ab7/000000?text=+) `#673ab7`   
Secondary Color: ![#303030](https://via.placeholder.com/15/303030/000000?text=+) `#303030`      
Tertiary Color: ![#515151](https://via.placeholder.com/15/515151/000000?text=+) `#515151`         

To Make the UI look better, the NuGet MaterialDesignThemes.Wpf was installed and the Windows Skinned.

# Arbeitsjournal:
Please look at the Kanban board Tickets on GitKraken Globoards.

# Prototype:
The Tutorial which was used to create the Prototype was: [WPF in C# with MVVM using Caliburn Micro by Tim COrey](https://youtu.be/laPFq3Fhs8k). It is a very basic and rudimentary Prototype of little to none Significance, as I decided to focus on the Main Project as soon as I got a simple MVVM Pattern up.

# Mockups:
![Mockups](https://github.com/Zayden16/m120pa/blob/master/docs/images/Mockups.png)  

## LoginView:
In this View the User can login to his already exisiting account. Additionally, there is a Logo, exit button and a login button. The User enters his Credentials and is Authenticated if his Credentials matches the Credentials stored in the Database. There is also an Exit button which obviously, closes the application.

## MainView:
In this View the User can see Alerts and Statistics on the go. For example like how many Users are there, how many cars, etc.

## CarsView:
In this View the User can see all of the Cars in the Database. Additionally he can add new Cars and delete existing ones. You should be able to modify existing Cars aswell. Clicking the button on the top should take the input from boxes and create a new tuple in the Database. The View and its contents should also be automatically refreshed.

## UsersView: 
In this View the User can see the Users. Only an Administrator User can see this View. Additionally he can add new Users and delete existing ones. The Cencept is more or less the same as the CarsView.

## InfoView: 
Misc View with diverse Information. Like the author, version information etc.


# ER Diagram:
![ER](https://github.com/Zayden16/m120pa/blob/master/docs/images/neptunDataDiagram.png)  
 
