This is a music Employment management system.=> Padlet link =>

1.https://padlet.com/christinebittle/passion-project-async-presentations-jn16e3wljfv2nju7/wish/XGyBQbl2ePY0WL6K 


Feedback:- F(feedback) R(Response)
F: I'd also like to see an "AcademyDataController" to manage information about the academies in the system:

R: I have created an academydatacontroller and academycontroller for my extra feature for the 3rd table for academies. 
Some related methods can also be planned here, including:

F: ListLessonsForInstructor : 
R: I have shown total lessons for all instructors in a list. I will also run this in a future run for the development to further have better filter to list by lesson, instructors

F: ListLessonsForAcademy: 
R: I will implement this in a future run of the development.

F: It is a bit odd that you have a M-M bridge between lessons and academies. I would think that a lesson has one instructor and is taught at one academy, allowing you to have a second lesson by the same instructor at a different academy, or a third lesson taught by a different instructor at the same academy:

R: I now have one acamemy to have multiple instructors.
   one instructor can be at one academy

For extra features: 

1. I have incorporated bootstrap libraries to make my system alot presentatble using human interaction components such as red color for a warning for delete, individual cards to show instructors making it easier to view them. There also other links and buttons through out the system that allow a gradual flow of the system. 
2. The system is responsive and appealing.
3. Created the 3rd table and Applied crud 
4. Understood the curl interface alot better after displaying academy CRUD operations on command line interface. 
5. Used sysmentic and summary blocks to comment on my whole document. 

Challenge: 
1. I was trying to update a database table name for academy- however the follow through wasnt as expected. I had to make multiple other changes whcih did not reflect as intended. THereafter i droped the table. Deleted all the migrations. Thereafter i created another migration to migrate everything on the database a fresh and the problem of adding viewing data for the academy table was sorted out. 


Additional notes
1. Engaged with Cherry on padlet => " I like how all restaurants are displayed, with the budgets! looking forward to visiting a few places! Viewing with star ratings would be a nice to have future development :"


Main Targeted Future Improvement: 
1. Create the an exception view for The academy table to allow filtering of instructors and Lessons 
2. Showing the instructor and time they are teaching to avoid clashes
3. SHow a drop down of instruments and when they are dated
4. Intergrate payroll to the system
5. Have an admin and user side

