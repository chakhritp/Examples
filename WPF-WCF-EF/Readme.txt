Layered Architecture Sample Application 4.5.1 - JANUARY 2014 Release (for .NET 4.5.1)
by Serena Yeoh (serena_yeoh@yahoo.com)

LAYERED ARCHITECTURE SAMPLE
http://layersample.codeplex.com/

Latest Update: JANUARY 2014

INTRODUCTION
============

Layered Architecture Sample is designed to demonstrate how to apply the 
Layered Architecture Pattern with various Microsoft .NET Technologies 
that are available today. It is aimed at illustrating how code of similar 
responsibilities can be factored into multiple logical layers which are 
applicable in most of today's enterprise applications.

The primary objective of the sample is to focus on layering and therefore, certain 
cross-cutting functionalities have been omitted to maintain its simplicity.


1. PRE-REQUISITES
=================

1.1 VISUAL STUDIO 2013

    This release of Layered Architecture Sample is only supported in Visual Studio
    2013.

	Visual Studio 2012 developers should download the June 2013 release of this 
	sample. (for .NET 4.5)
	http://layersample.codeplex.com/releases/view/107797

    Visual Studio 2010 developers should download the August 2010 release of 
    this sample. (for .NET 4.0)
    http://layersample.codeplex.com/releases/view/47627
    
    Visual Studio 2008 SP1 developers should download the January 2009 release of 
    this sample. (for .NET 3.5 SP1)
    http://layersample.codeplex.com/releases/view/22510

    Visual Studio 2008 developers should downlad the November 2008 release of this
    sample. (for .NET 3.5)
    http://layersample.codeplex.com/releases/view/19929
    
    Visual Studio 2005 developers should download the March 2008 release of this
    sample. (for .NET 3.0)
    http://layersample.codeplex.com/releases/view/11916


1.2 CONFIGURING THE WORKFLOW INSTANCE STORE

    This application requires that the Workflow Instance Store is created and 
    properly configured in ONE database named WorkflowInstanceStore.

    If you have chosen different database names, you may configure this application
    to use them via the config files.

    If you have not configured your Workflow Instance Store, please refer to the
    following steps:

    1. Open SQL Server Management Studio and create a new database. 
       i.e. WorkflowInstanceStore

    2. Once the database is created, go to File->Open->File
    
    3. Navigate to the folder 
       %WINDIR%\Microsoft.NET\Framework\v4.xxx\SQL\EN

    4. Open the following scripts:
       a. SqlWorkflowInstanceStoreSchema.sql
       b. SqlWorkflowInstanceStoreLogic.sql
       c. SqlWorkflowInstanceStoreSchemaUpgrade.sql

    5. Ensure that the database i.e. WorkflowInstanceStore, is selected in the 
       database drop down.
 
    6. Execute the scripts in the order above.


2. SETUP INSTRUCTIONS
=====================

    1) Run the script provided in the Scripts folder to create the sample 
       database. Verify you have the LeaveSample database created after 
       execution. 
	   
	   Note: You can also deploy the database from the Database project.

    2) Configure the credentials to your database in the web.config file of the
       LeaveSample.Host.Web project.

    3) Right-click on the Solution, click on Enable Nuget Package Restore.
	
    4) Compile and run the solution.


3. MORE INFORMATION ON THE APPLICATION ARCHITECTURE
===================================================

For more information on Layered Architecture, please visit
http://curah.microsoft.com/50302/layered-architecture