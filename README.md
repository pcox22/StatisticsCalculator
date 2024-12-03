# StatisticsCalculator

# KSU SWE 3643 Software Testing and Quality Assurance Semester Project: Web-Based Calculator
This aim of this project is to create an online calculator which allows users to calculate basic statistical values

## Table of Contents
- [Introduction](#ksu-swe-3643-software-testing-and-quality-assurance-semester-project-web-based-calculator)
- [Table of Contents](#table-of-contents)
- [Team Members](#team-members)
- [Architecture](#architecture)
- [Environment](#environment)
- [Executing the Web Application](#executing-the-web-application)
- [Executing Unit Tests](#executing-unit-tests)
- [Reviewing Unit Test Coverage](#reviewing-unit-test-coverage)
- [Executing End-to-End Tests](#executing-end-to-end-tests)

# Team Members
#### Constant Nortey Jr.
#### Patrick Cox

# Architecture
![Architecture](https://github.com/user-attachments/assets/5407d18f-5fa6-4272-b460-c71abae530be)

# Environment
This is a cross-platform application and should work in Windows 10+, Mac OSx Ventura+, and Linux environments. Note that the application has only been carefully tested in Windows 11.

To prepare your environment to execute this application:
 1. Download and install the latest version of any C# IDE. Most are able to run C#.Net Applications. I would recommend JetBrains Rider. [Click here to be redirected to their website](https://www.jetbrains.com/rider/download/#section=windows)

 2. You can either
## Executing the Web Application
```bash
$ dotnet run
info: Extensions.Hosting.AsyncInitialization.RootInitializer[0]
      Starting async initialization
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:60012
```
## Executing Unit Tests
```bash
$ dotnet test

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.
Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:   132, Skipped:     0, Total:   132, Duration: 39 ms - HighMatch.Compass.UnitTest.Extensions.dll (net7.0)
```
## Reviewing Unit Test Coverage
![image](https://github.com/user-attachments/assets/a70f011d-7655-4a20-b6be-c27cacdc8028)

## Executing End-To-End Tests
```bash
# From /Users/jeff/projects/swe-3643-spring-2024-project/src/Calculator/CalculatorEndToEndTests

❯ PS C:\Users\Constant Jr\Documents\GitHub\StatisticsCalculator\StatisticsCalculator> dotnet test 
  Determining projects to restore...
  All projects are up-to-date for restore.
  PlaywrightUITest -> C:\Users\Constant Jr\Documents\GitHub\StatisticsCalculator\StatisticsCalculator\PlaywrightUITest\bin\Debug\net6.0\PlaywrightU
  ITest.dll
  LogicModule -> C:\Users\Constant Jr\Documents\GitHub\StatisticsCalculator\StatisticsCalculator\LogicModule\bin\Debug\net7.0\LogicModule.dll       
Test run for C:\Users\Constant Jr\Documents\GitHub\StatisticsCalculator\StatisticsCalculator\PlaywrightUITest\bin\Debug\net6.0\PlaywrightUITest.dll (.NETCoreApp,Version=v6.0)
Microsoft (R) Test Execution Command Line Tool Version 17.4.0 (x64)
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:    17, Skipped:     0, Total:    17, Duration: 28 ms - StatCalcTest.dll (net7.0)
```
# Final Video Presentation
link will be here
