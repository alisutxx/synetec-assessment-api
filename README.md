# Alice:
Hello and thank you for taking your time to review my solution to the assessment!

I decided to use the CQRS pattern for this. I created only one controller for everything that is employee related and decided to continue with the Bonus Pool Service, but changed the methods inside of it (two methods to calculate the bonus pool percentage and the bonus amount).

I created a BaseController class with a generic method that could be used in every controller to handle the endpoints response.
For Read requests, I created a class called EmployeeQueries where I would process the requests received in the API endpoints. 


For testing, I decided to use XUnit and created another project where I mocked the database and made the two unit test class derive from IDisposable in order to implement the same setup for all the methods.

I used AutoMapper to map db entities to other Dtos I have made.

I tried to respect the SOLID principles and some principles of object calisthenics.

I am eager to learn more and I am enthusiastic about what the future will bring.

Thank you!

# Synetec Basic .Net API assessement

This is Synetec's basic API developer assessment.

If you are reading this, you most probably have been asked to complete this assessment as part of Synetec's interview process.

In this repository, you will find the base project and instructions on what to do with them. 

## How to complete this test

Please follow the instructions in the Instructions.pdf, found in this repository

Please explain the work that you did or any challenges that you faced, either by comments in code or in an email. 
In case the requirements are not met or they are not finished please explain the reasoning behind that.

## How to submit your completed test

To sumbit your test, please 
1. Fork this repository
2. Complete the test as per the instructions PDF 
3. Commit your changes to your (forked) repo 
4. Send us an http link to your repo that contains the completed test 

**This repo is Read-Only!!** So please don't try to open a pull request
