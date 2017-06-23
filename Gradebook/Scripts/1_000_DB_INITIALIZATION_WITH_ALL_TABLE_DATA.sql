-- Script Date: 6/21/2017 10:51 PM  - ErikEJ.SqlCeScripting version 3.5.2.64
SELECT 1;
PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [Roles] (
  [roleID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [role] nvarchar(50) NOT NULL
);
CREATE TABLE [Users] (
  [userID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [userName] nvarchar(50) NOT NULL
, [password] nvarchar(100) NULL
, [roleID] INTEGER NULL
, [resetPassword] bit DEFAULT 0 NOT NULL
, FOREIGN KEY ([roleID]) REFERENCES [Roles] ([roleID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [Persons] (
  [personID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [firstName] nvarchar(50) NOT NULL
, [lastName] nvarchar(50) NOT NULL
, [dateOfBirth] datetime NULL
, [street] nvarchar(50) NULL
, [city] nvarchar(50) NULL
, [stateCode] nchar(2) NULL
, [zipCode] nchar(5) NULL
, [gender] nvarchar(50) NOT NULL
, [phoneNumber] nvarchar(50) NULL
, [email] nvarchar(50) NULL
);
CREATE TABLE [Teachers] (
  [teacherID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [personID] INTEGER NOT NULL
, [userID] INTEGER NULL
, FOREIGN KEY ([personID]) REFERENCES [Persons] ([personID]) ON DELETE NO ACTION ON UPDATE NO ACTION
, FOREIGN KEY ([userID]) REFERENCES [Users] ([userID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [Students] (
  [studentID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [personID] INTEGER NOT NULL
, [userID] INTEGER NULL
, FOREIGN KEY ([personID]) REFERENCES [Persons] ([personID]) ON DELETE NO ACTION ON UPDATE NO ACTION
, FOREIGN KEY ([userID]) REFERENCES [Users] ([userID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [Credits] (
  [creditID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [type] nvarchar(50) NOT NULL
, [months] INTEGER NOT NULL
);
CREATE TABLE [Courses] (
  [courseID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [creditID] INTEGER NULL
, [name] nvarchar(50) NOT NULL
, [description] nvarchar(50) NOT NULL
, FOREIGN KEY ([creditID]) REFERENCES [Credits] ([creditID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [TaughtCourses] (
  [taughtCourseID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [teacherID] INTEGER NOT NULL
, [courseID] INTEGER NOT NULL
, FOREIGN KEY ([courseID]) REFERENCES [Courses] ([courseID]) ON DELETE CASCADE ON UPDATE CASCADE
, FOREIGN KEY ([teacherID]) REFERENCES [Teachers] ([teacherID]) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE [RegisteredStudents] (
  [registeredStudentID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [studentID] INTEGER NOT NULL
, [taughtCourseID] INTEGER NOT NULL
, FOREIGN KEY ([studentID]) REFERENCES [Students] ([studentID]) ON DELETE NO ACTION ON UPDATE NO ACTION
, FOREIGN KEY ([taughtCourseID]) REFERENCES [TaughtCourses] ([taughtCourseID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [Categories] (
  [categoryID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [taughtCourseID] INTEGER NULL
, [name] nvarchar(50) NOT NULL
, [weight] INTEGER NOT NULL
, FOREIGN KEY ([taughtCourseID]) REFERENCES [TaughtCourses] ([taughtCourseID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [Assignments] (
  [assignmentID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [categoryID] INTEGER NULL
, [name] nvarchar(50) NOT NULL
, [description] nvarchar(50) NOT NULL
, [assignedDate] datetime NOT NULL
, [dueDate] datetime NOT NULL
, [possiblePoints] INTEGER NOT NULL
, FOREIGN KEY ([categoryID]) REFERENCES [Categories] ([categoryID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [Grades] (
  [gradeID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [registeredStudentID] INTEGER NOT NULL
, [assignmentID] INTEGER NOT NULL
, [actualPoints] INTEGER NOT NULL
, [comment] nvarchar(50) NOT NULL
, FOREIGN KEY ([assignmentID]) REFERENCES [Assignments] ([assignmentID]) ON DELETE NO ACTION ON UPDATE NO ACTION
, FOREIGN KEY ([registeredStudentID]) REFERENCES [RegisteredStudents] ([registeredStudentID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE [Admins] (
  [adminID] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
, [personID] INTEGER NOT NULL
, [userID] INTEGER NULL
, FOREIGN KEY ([personID]) REFERENCES [Persons] ([personID]) ON DELETE NO ACTION ON UPDATE NO ACTION
, FOREIGN KEY ([userID]) REFERENCES [Users] ([userID]) ON DELETE NO ACTION ON UPDATE NO ACTION
);
INSERT INTO [Roles] ([roleID],[role]) VALUES (
1,'Student');
INSERT INTO [Roles] ([roleID],[role]) VALUES (
2,'Teacher');
INSERT INTO [Roles] ([roleID],[role]) VALUES (
3,'Administrator');
INSERT INTO [Users] ([userID],[userName],[password],[roleID],[resetPassword]) VALUES (
1,'amy.stewart','83FAEACAA189777DC154A43A502A7A73899DDB029C245777E454F1D7C25CA1D2',1,1);
INSERT INTO [Users] ([userID],[userName],[password],[roleID],[resetPassword]) VALUES (
2,'brett.jackson','83FAEACAA189777DC154A43A502A7A73899DDB029C245777E454F1D7C25CA1D2',1,1);
INSERT INTO [Users] ([userID],[userName],[password],[roleID],[resetPassword]) VALUES (
3,'marcus.patterson','83FAEACAA189777DC154A43A502A7A73899DDB029C245777E454F1D7C25CA1D2',1,1);
INSERT INTO [Users] ([userID],[userName],[password],[roleID],[resetPassword]) VALUES (
4,'tammy.mann','83FAEACAA189777DC154A43A502A7A73899DDB029C245777E454F1D7C25CA1D2',1,1);
INSERT INTO [Users] ([userID],[userName],[password],[roleID],[resetPassword]) VALUES (
5,'richard.barnes','83FAEACAA189777DC154A43A502A7A73899DDB029C245777E454F1D7C25CA1D2',1,1);
INSERT INTO [Users] ([userID],[userName],[password],[roleID],[resetPassword]) VALUES (
6,'mercedes.clarkson','83FAEACAA189777DC154A43A502A7A73899DDB029C245777E454F1D7C25CA1D2',1,1);
INSERT INTO [Users] ([userID],[userName],[password],[roleID],[resetPassword]) VALUES (
7,'bob.monroe','83FAEACAA189777DC154A43A502A7A73899DDB029C245777E454F1D7C25CA1D2',2,1);
INSERT INTO [Users] ([userID],[userName],[password],[roleID],[resetPassword]) VALUES (
8,'jason.franks','83FAEACAA189777DC154A43A502A7A73899DDB029C245777E454F1D7C25CA1D2',2,1);
INSERT INTO [Users] ([userID],[userName],[password],[roleID],[resetPassword]) VALUES (
9,'lauren.hill','83FAEACAA189777DC154A43A502A7A73899DDB029C245777E454F1D7C25CA1D2',2,1);
INSERT INTO [Users] ([userID],[userName],[password],[roleID],[resetPassword]) VALUES (
10,'peggy.walcott','83FAEACAA189777DC154A43A502A7A73899DDB029C245777E454F1D7C25CA1D2',2,1);
INSERT INTO [Users] ([userID],[userName],[password],[roleID],[resetPassword]) VALUES (
11,'shawn.carter','83FAEACAA189777DC154A43A502A7A73899DDB029C245777E454F1D7C25CA1D2',3,1);
INSERT INTO [Users] ([userID],[userName],[password],[roleID],[resetPassword]) VALUES (
12,'porsha.gates','83FAEACAA189777DC154A43A502A7A73899DDB029C245777E454F1D7C25CA1D2',3,1);
INSERT INTO [Persons] ([personID],[firstName],[lastName],[dateOfBirth],[street],[city],[stateCode],[zipCode],[gender],[phoneNumber],[email]) VALUES (
1,'Amy','Stewart','2005-02-17 00:00:00.000','4417 Brannon Street','Los Angeles','CA','90017','Female','8053223938','amy.stewart@gmail.com');
INSERT INTO [Persons] ([personID],[firstName],[lastName],[dateOfBirth],[street],[city],[stateCode],[zipCode],[gender],[phoneNumber],[email]) VALUES (
2,'Brett','Jackson','2004-04-11 00:00:00.000','2479 New York Avenue','Los Angeles','CA','90071','Male','8182106232','brett.jackson@gmail.com');
INSERT INTO [Persons] ([personID],[firstName],[lastName],[dateOfBirth],[street],[city],[stateCode],[zipCode],[gender],[phoneNumber],[email]) VALUES (
3,'Marcus','Patterson','2003-06-12 00:00:00.000','4003 Brannon Street','Los Angeles','CA','90017','Male','2132886979','marcus.patterson@gmail.com');
INSERT INTO [Persons] ([personID],[firstName],[lastName],[dateOfBirth],[street],[city],[stateCode],[zipCode],[gender],[phoneNumber],[email]) VALUES (
4,'Tammy','Mann','2004-01-31 00:00:00.000','265 Evergreen Lane','Los Angeles','CA','90036','Female','3235490398','tammy.mann@gmail.com');
INSERT INTO [Persons] ([personID],[firstName],[lastName],[dateOfBirth],[street],[city],[stateCode],[zipCode],[gender],[phoneNumber],[email]) VALUES (
5,'Richard','Barnes','2005-03-05 00:00:00.000','4528 Southside Lane','Los Angeles','CA','90045','Male','3237765995','richard.barnes@gmail.com');
INSERT INTO [Persons] ([personID],[firstName],[lastName],[dateOfBirth],[street],[city],[stateCode],[zipCode],[gender],[phoneNumber],[email]) VALUES (
6,'Mercedes','Clarkson','2003-02-01 00:00:00.000','98 Felosa Drive','Los Angeles','CA','90017','Female','3239617644','mercedes.clarkson@gmail.com');
INSERT INTO [Persons] ([personID],[firstName],[lastName],[dateOfBirth],[street],[city],[stateCode],[zipCode],[gender],[phoneNumber],[email]) VALUES (
7,'Bob','Monroe','1982-10-01 00:00:00.000','4366 Glendale Avenue','Los Angeles','CA','90017','Male','8186803264','bob.monroe@gmail.com');
INSERT INTO [Persons] ([personID],[firstName],[lastName],[dateOfBirth],[street],[city],[stateCode],[zipCode],[gender],[phoneNumber],[email]) VALUES (
8,'Jason','Franks','1975-12-05 00:00:00.000','4028 Meadowbrook Mall Road','Los Angeles','CA','90046','Male','3108542553','jason.franks@gmail.com');
INSERT INTO [Persons] ([personID],[firstName],[lastName],[dateOfBirth],[street],[city],[stateCode],[zipCode],[gender],[phoneNumber],[email]) VALUES (
9,'Lauren','Hill','1994-10-31 00:00:00.000','1943 Nickel Road','Los Angeles','CA','90017','Female','6266899895','lauren.hill@gmail.com');
INSERT INTO [Persons] ([personID],[firstName],[lastName],[dateOfBirth],[street],[city],[stateCode],[zipCode],[gender],[phoneNumber],[email]) VALUES (
10,'Peggy','Walcott','1987-08-04 00:00:00.000','868 Bel Meadow Drive','Los Angeles','CA','90017','Female','9094325779','peggy.walcott@gmail.com');
INSERT INTO [Persons] ([personID],[firstName],[lastName],[dateOfBirth],[street],[city],[stateCode],[zipCode],[gender],[phoneNumber],[email]) VALUES (
11,'Shawn','Carter','1970-05-23 00:00:00.000','4314 Lowndes Hill Park Road','Los Angeles','CA','90017','Male','6614645651','shawn.carter@gmail.com');
INSERT INTO [Persons] ([personID],[firstName],[lastName],[dateOfBirth],[street],[city],[stateCode],[zipCode],[gender],[phoneNumber],[email]) VALUES (
12,'Porsha','Gates','1964-02-11 00:00:00.000','2137 Hilltop Haven Drive','Los Angeles','CA','90001','Female','9738781040','porsha.gates@gmail.com');
INSERT INTO [Teachers] ([teacherID],[personID],[userID]) VALUES (
1,7,7);
INSERT INTO [Teachers] ([teacherID],[personID],[userID]) VALUES (
2,8,8);
INSERT INTO [Teachers] ([teacherID],[personID],[userID]) VALUES (
3,9,9);
INSERT INTO [Teachers] ([teacherID],[personID],[userID]) VALUES (
4,10,10);
INSERT INTO [Students] ([studentID],[personID],[userID]) VALUES (
1,1,1);
INSERT INTO [Students] ([studentID],[personID],[userID]) VALUES (
2,2,2);
INSERT INTO [Students] ([studentID],[personID],[userID]) VALUES (
3,3,3);
INSERT INTO [Students] ([studentID],[personID],[userID]) VALUES (
4,4,4);
INSERT INTO [Students] ([studentID],[personID],[userID]) VALUES (
5,5,5);
INSERT INTO [Students] ([studentID],[personID],[userID]) VALUES (
6,6,6);
INSERT INTO [Credits] ([creditID],[type],[months]) VALUES (
1,'Quarter',3);
INSERT INTO [Credits] ([creditID],[type],[months]) VALUES (
2,'Semester',4);
INSERT INTO [Credits] ([creditID],[type],[months]) VALUES (
3,'Term',6);
INSERT INTO [Courses] ([courseID],[creditID],[name],[description]) VALUES (
1,2,'Math','Math Semester');
INSERT INTO [Courses] ([courseID],[creditID],[name],[description]) VALUES (
2,2,'English','English Semester');
INSERT INTO [Courses] ([courseID],[creditID],[name],[description]) VALUES (
3,2,'Science','Science Semester');
INSERT INTO [Courses] ([courseID],[creditID],[name],[description]) VALUES (
4,2,'History','History Semester');
INSERT INTO [Courses] ([courseID],[creditID],[name],[description]) VALUES (
5,1,'Math','Math Quarter');
INSERT INTO [Courses] ([courseID],[creditID],[name],[description]) VALUES (
6,1,'English','English Quarter');
INSERT INTO [Courses] ([courseID],[creditID],[name],[description]) VALUES (
7,3,'Math','Math Term');
INSERT INTO [Courses] ([courseID],[creditID],[name],[description]) VALUES (
8,3,'English','English Term');
INSERT INTO [TaughtCourses] ([taughtCourseID],[teacherID],[courseID]) VALUES (
1,1,1);
INSERT INTO [TaughtCourses] ([taughtCourseID],[teacherID],[courseID]) VALUES (
2,1,5);
INSERT INTO [TaughtCourses] ([taughtCourseID],[teacherID],[courseID]) VALUES (
3,1,7);
INSERT INTO [TaughtCourses] ([taughtCourseID],[teacherID],[courseID]) VALUES (
4,2,2);
INSERT INTO [TaughtCourses] ([taughtCourseID],[teacherID],[courseID]) VALUES (
5,2,6);
INSERT INTO [TaughtCourses] ([taughtCourseID],[teacherID],[courseID]) VALUES (
6,2,8);
INSERT INTO [TaughtCourses] ([taughtCourseID],[teacherID],[courseID]) VALUES (
7,3,3);
INSERT INTO [TaughtCourses] ([taughtCourseID],[teacherID],[courseID]) VALUES (
8,4,4);
INSERT INTO [RegisteredStudents] ([registeredStudentID],[studentID],[taughtCourseID]) VALUES (
1,1,1);
INSERT INTO [RegisteredStudents] ([registeredStudentID],[studentID],[taughtCourseID]) VALUES (
2,2,1);
INSERT INTO [RegisteredStudents] ([registeredStudentID],[studentID],[taughtCourseID]) VALUES (
3,3,1);
INSERT INTO [RegisteredStudents] ([registeredStudentID],[studentID],[taughtCourseID]) VALUES (
4,4,1);
INSERT INTO [RegisteredStudents] ([registeredStudentID],[studentID],[taughtCourseID]) VALUES (
5,5,1);
INSERT INTO [RegisteredStudents] ([registeredStudentID],[studentID],[taughtCourseID]) VALUES (
6,6,1);
INSERT INTO [RegisteredStudents] ([registeredStudentID],[studentID],[taughtCourseID]) VALUES (
7,2,4);
INSERT INTO [RegisteredStudents] ([registeredStudentID],[studentID],[taughtCourseID]) VALUES (
8,4,4);
INSERT INTO [RegisteredStudents] ([registeredStudentID],[studentID],[taughtCourseID]) VALUES (
9,6,4);
INSERT INTO [RegisteredStudents] ([registeredStudentID],[studentID],[taughtCourseID]) VALUES (
10,1,7);
INSERT INTO [RegisteredStudents] ([registeredStudentID],[studentID],[taughtCourseID]) VALUES (
11,3,7);
INSERT INTO [RegisteredStudents] ([registeredStudentID],[studentID],[taughtCourseID]) VALUES (
12,5,7);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
1,1,'Homework',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
2,1,'Participation',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
3,1,'Exams',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
4,1,'Quizzes',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
5,1,'Projects',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
6,4,'Homework',50);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
7,4,'Projects',50);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
8,7,'Projects',100);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
9,4,'Participation',0);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
10,4,'Quizzes',0);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
11,4,'Exams',0);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
12,7,'Homework',0);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
13,7,'Participation',0);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
14,7,'Exams',0);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
15,7,'Quizzes',0);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
16,2,'Exams',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
17,2,'Homework',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
18,2,'Participation',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
19,2,'Projects',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
20,2,'Quizzes',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
21,3,'Exams',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
22,3,'Homework',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
23,3,'Participation',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
24,3,'Projects',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
25,3,'Quizzes',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
26,5,'Exams',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
27,5,'Homework',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
28,5,'Projects',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
29,5,'Participation',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
30,5,'Quizzes',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
31,6,'Exams',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
32,6,'Homework',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
33,6,'Participation',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
34,6,'Projects',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
35,6,'Quizzes',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
36,8,'Exams',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
37,8,'Homework',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
38,8,'Participation',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
39,8,'Projects',20);
INSERT INTO [Categories] ([categoryID],[taughtCourseID],[name],[weight]) VALUES (
40,8,'Quizzes',20);
INSERT INTO [Assignments] ([assignmentID],[categoryID],[name],[description],[assignedDate],[dueDate],[possiblePoints]) VALUES (
1,1,'Homework 1','Description 1','2017-06-12 00:00:00.000','2017-06-13 00:00:00.000',100);
INSERT INTO [Assignments] ([assignmentID],[categoryID],[name],[description],[assignedDate],[dueDate],[possiblePoints]) VALUES (
2,1,'Homework 2','Description 2','2017-06-13 00:00:00.000','2017-06-14 00:00:00.000',100);
INSERT INTO [Assignments] ([assignmentID],[categoryID],[name],[description],[assignedDate],[dueDate],[possiblePoints]) VALUES (
3,1,'Homework 3','Description 3','2017-06-14 00:00:00.000','2017-06-15 00:00:00.000',100);
INSERT INTO [Assignments] ([assignmentID],[categoryID],[name],[description],[assignedDate],[dueDate],[possiblePoints]) VALUES (
4,2,'Project 1','Description 4','2017-06-15 00:00:00.000','2017-06-16 00:00:00.000',100);
INSERT INTO [Assignments] ([assignmentID],[categoryID],[name],[description],[assignedDate],[dueDate],[possiblePoints]) VALUES (
5,3,'Attendance 1','Description 5','2017-06-12 00:00:00.000','2017-12-20 00:00:00.000',100);
INSERT INTO [Assignments] ([assignmentID],[categoryID],[name],[description],[assignedDate],[dueDate],[possiblePoints]) VALUES (
6,4,'Test 1','Description 6','2017-06-16 00:00:00.000','2017-06-16 00:00:00.000',100);
INSERT INTO [Assignments] ([assignmentID],[categoryID],[name],[description],[assignedDate],[dueDate],[possiblePoints]) VALUES (
7,5,'Participation','Description 7','2017-06-12 00:00:00.000','2017-12-20 00:00:00.000',100);
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
1,1,1,90,'A');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
2,2,1,80,'B-');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
3,3,1,79,'C+');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
4,4,1,75,'C');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
5,5,1,60,'D-');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
6,6,1,50,'F-');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
7,1,2,85,'B');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
8,2,2,100,'A+');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
9,3,2,80,'B');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
10,4,2,70,'C-');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
11,5,2,75,'C');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
12,6,2,90,'A-');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
13,1,3,100,'A+');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
14,2,3,100,'A+');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
15,3,3,100,'A+');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
16,4,3,100,'A+');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
17,5,3,100,'A+');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
18,6,3,100,'A+');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
19,1,4,80,'B-');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
20,2,4,70,'C-');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
21,3,4,75,'C');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
22,4,4,85,'B+');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
23,5,4,90,'A-');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
24,6,4,100,'A+');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
25,1,5,90,'A-');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
26,2,5,90,'A-');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
27,3,5,90,'A-');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
28,4,5,90,'A-');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
29,5,5,90,'A-');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
30,6,5,90,'A-');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
31,1,6,95,'A');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
32,2,6,95,'A');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
33,3,6,95,'A');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
34,4,6,95,'A');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
35,5,6,95,'A');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
36,6,6,95,'A');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
37,1,7,100,'A+');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
38,2,7,100,'A+');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
39,3,7,100,'A+');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
40,4,7,100,'A+');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
41,5,7,100,'A+');
INSERT INTO [Grades] ([gradeID],[registeredStudentID],[assignmentID],[actualPoints],[comment]) VALUES (
42,6,7,100,'A+');
INSERT INTO [Admins] ([adminID],[personID],[userID]) VALUES (
1,11,11);
INSERT INTO [Admins] ([adminID],[personID],[userID]) VALUES (
2,12,12);
CREATE INDEX [IX_Assignments_Assignments] ON [Assignments] ([assignmentID] ASC);
COMMIT;

