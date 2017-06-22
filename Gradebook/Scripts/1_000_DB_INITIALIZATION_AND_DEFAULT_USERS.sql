CREATE TABLE [Admins] ( [adminID] integer PRIMARY KEY AUTOINCREMENT NOT NULL, [personID] integer NOT NULL, [userID] integer , FOREIGN KEY ([personID]) REFERENCES [Persons]([personID]), FOREIGN KEY ([userID]) REFERENCES [Users]([userID]) )

CREATE TABLE [Assignments] ( [assignmentID] integer PRIMARY KEY AUTOINCREMENT NOT NULL, [categoryID] integer, [name] varchar(50) NOT NULL COLLATE NOCASE, [description] varchar(50) NOT NULL COLLATE NOCASE, [assignedDate] datetime NOT NULL COLLATE NOCASE, [dueDate] datetime NOT NULL COLLATE NOCASE, [possiblePoints] integer NOT NULL , FOREIGN KEY ([categoryID]) REFERENCES [Categories]([categoryID]) )

CREATE TABLE [Categories] ( [categoryID] integer PRIMARY KEY AUTOINCREMENT NOT NULL, [taughtCourseID] integer, [name] varchar(50) NOT NULL COLLATE NOCASE, [weight] integer NOT NULL , FOREIGN KEY ([taughtCourseID]) REFERENCES [TaughtCourses]([taughtCourseID]) )

CREATE TABLE [Courses] ( [courseID] integer PRIMARY KEY AUTOINCREMENT NOT NULL, [creditID] integer, [name] varchar(50) NOT NULL COLLATE NOCASE, [description] varchar(50) NOT NULL COLLATE NOCASE , FOREIGN KEY ([creditID]) REFERENCES [Credits]([creditID]) )

CREATE TABLE [Credits] ( [creditID] integer PRIMARY KEY AUTOINCREMENT NOT NULL, [type] varchar(50) NOT NULL COLLATE NOCASE, [months] integer NOT NULL )

CREATE TABLE [Grades] ( [gradeID] integer PRIMARY KEY AUTOINCREMENT NOT NULL, [registeredStudentID] integer NOT NULL, [assignmentID] integer NOT NULL, [actualPoints] integer NOT NULL, [comment] varchar(50) NOT NULL COLLATE NOCASE , FOREIGN KEY ([registeredStudentID]) REFERENCES [RegisteredStudents]([registeredStudentID]), FOREIGN KEY ([assignmentID]) REFERENCES [Assignments]([assignmentID]) )

CREATE TABLE [Persons] ( [personID] integer PRIMARY KEY AUTOINCREMENT NOT NULL, [firstName] varchar(50) NOT NULL COLLATE NOCASE, [lastName] varchar(50) NOT NULL COLLATE NOCASE, [dateOfBirth] datetime COLLATE NOCASE, [street] varchar(50) COLLATE NOCASE, [city] varchar(50) COLLATE NOCASE, [stateCode] char(2) COLLATE NOCASE, [zipCode] char(5) COLLATE NOCASE, [gender] varchar(50) NOT NULL COLLATE NOCASE, [phoneNumber] varchar(50) COLLATE NOCASE, [email] varchar(50) COLLATE NOCASE )

CREATE TABLE [RegisteredStudents] ( [registeredStudentID] integer PRIMARY KEY AUTOINCREMENT NOT NULL, [studentID] integer NOT NULL, [taughtCourseID] integer NOT NULL , FOREIGN KEY ([studentID]) REFERENCES [Students]([studentID]), FOREIGN KEY ([taughtCourseID]) REFERENCES [TaughtCourses]([taughtCourseID]) )

CREATE TABLE [Roles] ( [roleID] integer NOT NULL, [role] varchar(50) NOT NULL COLLATE NOCASE, PRIMARY KEY ([roleID]) )

CREATE TABLE [Students] ( [studentID] integer PRIMARY KEY AUTOINCREMENT NOT NULL, [personID] integer NOT NULL, [userID] integer , FOREIGN KEY ([personID]) REFERENCES [Persons]([personID]), FOREIGN KEY ([userID]) REFERENCES [Users]([userID]) )

CREATE TABLE [TaughtCourses] ( [taughtCourseID] integer PRIMARY KEY AUTOINCREMENT NOT NULL, [teacherID] integer NOT NULL, [courseID] integer NOT NULL , FOREIGN KEY ([teacherID]) REFERENCES [Teachers]([teacherID]), FOREIGN KEY ([courseID]) REFERENCES [Courses]([courseID]) )

CREATE TABLE [Teachers] ( [teacherID] integer PRIMARY KEY AUTOINCREMENT NOT NULL, [personID] integer NOT NULL, [userID] integer , FOREIGN KEY ([personID]) REFERENCES [Persons]([personID]), FOREIGN KEY ([userID]) REFERENCES [Users]([userID]) )

CREATE TABLE [Users] ( [userID] integer NOT NULL, [userName] varchar(50) NOT NULL COLLATE NOCASE, [password] varchar(64) COLLATE NOCASE, [roleID] integer, [resetPassword] bit NOT NULL DEFAULT 0, PRIMARY KEY ([userID]) , FOREIGN KEY ([roleID]) REFERENCES [Roles]([roleID]) )

CREATE INDEX [Assignments_IX_Assignments] ON [Assignments] ([assignmentID] DESC)


SET IDENTITY_INSERT [dbo].[Admins] ON 
INSERT [dbo].[Admins] ([adminID], [personID], [userID]) VALUES (1, 11, 11)
INSERT [dbo].[Admins] ([adminID], [personID], [userID]) VALUES (2, 12, 12)
SET IDENTITY_INSERT [dbo].[Admins] OFF

SET IDENTITY_INSERT [dbo].[Assignments] ON 
INSERT [dbo].[Assignments] ([assignmentID], [categoryID], [name], [description], [assignedDate], [dueDate], [possiblePoints]) VALUES (1, 1, N'Homework 1', N'Description 1', CAST(N'2017-06-12' AS Date), CAST(N'2017-06-13' AS Date), 100)
INSERT [dbo].[Assignments] ([assignmentID], [categoryID], [name], [description], [assignedDate], [dueDate], [possiblePoints]) VALUES (2, 1, N'Homework 2', N'Description 2', CAST(N'2017-06-13' AS Date), CAST(N'2017-06-14' AS Date), 100)
INSERT [dbo].[Assignments] ([assignmentID], [categoryID], [name], [description], [assignedDate], [dueDate], [possiblePoints]) VALUES (3, 1, N'Homework 3', N'Description 3', CAST(N'2017-06-14' AS Date), CAST(N'2017-06-15' AS Date), 100)
INSERT [dbo].[Assignments] ([assignmentID], [categoryID], [name], [description], [assignedDate], [dueDate], [possiblePoints]) VALUES (4, 2, N'Project 1', N'Description 4', CAST(N'2017-06-15' AS Date), CAST(N'2017-06-16' AS Date), 100)
INSERT [dbo].[Assignments] ([assignmentID], [categoryID], [name], [description], [assignedDate], [dueDate], [possiblePoints]) VALUES (5, 3, N'Attendance 1', N'Description 5', CAST(N'2017-06-12' AS Date), CAST(N'2017-12-20' AS Date), 100)
INSERT [dbo].[Assignments] ([assignmentID], [categoryID], [name], [description], [assignedDate], [dueDate], [possiblePoints]) VALUES (6, 4, N'Test 1', N'Description 6', CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 100)
INSERT [dbo].[Assignments] ([assignmentID], [categoryID], [name], [description], [assignedDate], [dueDate], [possiblePoints]) VALUES (7, 5, N'Participation', N'Description 7', CAST(N'2017-06-12' AS Date), CAST(N'2017-12-20' AS Date), 100)
SET IDENTITY_INSERT [dbo].[Assignments] OFF

SET IDENTITY_INSERT [dbo].[Categories] ON 
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (1, 1, N'Homework', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (2, 1, N'Participation', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (3, 1, N'Exams', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (4, 1, N'Quizzes', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (5, 1, N'Projects', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (6, 4, N'Homework', 50)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (7, 4, N'Projects', 50)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (8, 7, N'Projects', 100)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (9, 4, N'Participation', 0)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (10, 4, N'Quizzes', 0)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (11, 4, N'Exams', 0)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (12, 7, N'Homework', 0)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (13, 7, N'Participation', 0)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (14, 7, N'Exams', 0)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (15, 7, N'Quizzes', 0)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (16, 2, N'Exams', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (17, 2, N'Homework', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (18, 2, N'Participation', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (19, 2, N'Projects', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (20, 2, N'Quizzes', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (21, 3, N'Exams', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (22, 3, N'Homework', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (23, 3, N'Participation', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (24, 3, N'Projects', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (25, 3, N'Quizzes', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (26, 5, N'Exams', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (27, 5, N'Homework', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (28, 5, N'Projects', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (29, 5, N'Participation', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (30, 5, N'Quizzes', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (31, 6, N'Exams', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (32, 6, N'Homework', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (33, 6, N'Participation', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (34, 6, N'Projects', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (35, 6, N'Quizzes', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (36, 8, N'Exams', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (37, 8, N'Homework', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (38, 8, N'Participation', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (39, 8, N'Projects', 20)
INSERT [dbo].[Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (40, 8, N'Quizzes', 20)
SET IDENTITY_INSERT [dbo].[Categories] OFF

SET IDENTITY_INSERT [dbo].[Courses] ON 
INSERT [dbo].[Courses] ([courseID], [creditID], [name], [description]) VALUES (1, 2, N'Math', N'Math Semester')
INSERT [dbo].[Courses] ([courseID], [creditID], [name], [description]) VALUES (2, 2, N'English', N'English Semester')
INSERT [dbo].[Courses] ([courseID], [creditID], [name], [description]) VALUES (3, 2, N'Science', N'Science Semester')
INSERT [dbo].[Courses] ([courseID], [creditID], [name], [description]) VALUES (4, 2, N'History', N'History Semester')
INSERT [dbo].[Courses] ([courseID], [creditID], [name], [description]) VALUES (5, 1, N'Math', N'Math Quarter')
INSERT [dbo].[Courses] ([courseID], [creditID], [name], [description]) VALUES (6, 1, N'English', N'English Quarter')
INSERT [dbo].[Courses] ([courseID], [creditID], [name], [description]) VALUES (7, 3, N'Math', N'Math Term')
INSERT [dbo].[Courses] ([courseID], [creditID], [name], [description]) VALUES (8, 3, N'English', N'English Term')
SET IDENTITY_INSERT [dbo].[Courses] OFF

SET IDENTITY_INSERT [dbo].[Credits] ON 
INSERT [dbo].[Credits] ([creditID], [type], [months]) VALUES (1, N'Quarter', 3)
INSERT [dbo].[Credits] ([creditID], [type], [months]) VALUES (2, N'Semester', 4)
INSERT [dbo].[Credits] ([creditID], [type], [months]) VALUES (3, N'Term', 6)
SET IDENTITY_INSERT [dbo].[Credits] OFF

SET IDENTITY_INSERT [dbo].[Grades] ON 
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (1, 1, 1, 90, N'A')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (2, 2, 1, 80, N'B-')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (3, 3, 1, 79, N'C+')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (4, 4, 1, 75, N'C')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (5, 5, 1, 60, N'D-')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (6, 6, 1, 50, N'F-')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (7, 1, 2, 85, N'B')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (8, 2, 2, 100, N'A+')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (9, 3, 2, 80, N'B')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (10, 4, 2, 70, N'C-')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (11, 5, 2, 75, N'C')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (12, 6, 2, 90, N'A-')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (13, 1, 3, 100, N'A+')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (14, 2, 3, 100, N'A+')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (15, 3, 3, 100, N'A+')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (16, 4, 3, 100, N'A+')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (17, 5, 3, 100, N'A+')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (18, 6, 3, 100, N'A+')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (19, 1, 4, 80, N'B-')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (20, 2, 4, 70, N'C-')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (21, 3, 4, 75, N'C')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (22, 4, 4, 85, N'B+')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (23, 5, 4, 90, N'A-')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (24, 6, 4, 100, N'A+')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (25, 1, 5, 90, N'A-')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (26, 2, 5, 90, N'A-')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (27, 3, 5, 90, N'A-')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (28, 4, 5, 90, N'A-')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (29, 5, 5, 90, N'A-')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (30, 6, 5, 90, N'A-')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (31, 1, 6, 95, N'A')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (32, 2, 6, 95, N'A')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (33, 3, 6, 95, N'A')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (34, 4, 6, 95, N'A')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (35, 5, 6, 95, N'A')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (36, 6, 6, 95, N'A')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (37, 1, 7, 100, N'A+')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (38, 2, 7, 100, N'A+')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (39, 3, 7, 100, N'A+')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (40, 4, 7, 100, N'A+')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (41, 5, 7, 100, N'A+')
INSERT [dbo].[Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (42, 6, 7, 100, N'A+')
SET IDENTITY_INSERT [dbo].[Grades] OFF

SET IDENTITY_INSERT [dbo].[Persons] ON 
INSERT [dbo].[Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (1, N'Amy', N'Stewart', CAST(N'2005-02-17' AS Date), N'4417 Brannon Street', N'Los Angeles', N'CA', N'90017', N'Female', N'8053223938', N'amy.stewart@gmail.com')
INSERT [dbo].[Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (2, N'Brett', N'Jackson', CAST(N'2004-04-11' AS Date), N'2479 New York Avenue', N'Los Angeles', N'CA', N'90071', N'Male', N'8182106232', N'brett.jackson@gmail.com')
INSERT [dbo].[Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (3, N'Marcus', N'Patterson', CAST(N'2003-06-12' AS Date), N'4003 Brannon Street', N'Los Angeles', N'CA', N'90017', N'Male', N'2132886979', N'marcus.patterson@gmail.com')
INSERT [dbo].[Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (4, N'Tammy', N'Mann', CAST(N'2004-01-31' AS Date), N'265 Evergreen Lane', N'Los Angeles', N'CA', N'90036', N'Female', N'3235490398', N'tammy.mann@gmail.com')
INSERT [dbo].[Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (5, N'Richard', N'Barnes', CAST(N'2005-03-05' AS Date), N'4528 Southside Lane', N'Los Angeles', N'CA', N'90045', N'Male', N'3237765995', N'richard.barnes@gmail.com')
INSERT [dbo].[Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (6, N'Mercedes', N'Clarkson', CAST(N'2003-02-01' AS Date), N'98 Felosa Drive', N'Los Angeles', N'CA', N'90017', N'Female', N'3239617644', N'mercedes.clarkson@gmail.com')
INSERT [dbo].[Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (7, N'Bob', N'Monroe', CAST(N'1982-10-01' AS Date), N'4366 Glendale Avenue', N'Los Angeles', N'CA', N'90017', N'Male', N'8186803264', N'bob.monroe@gmail.com')
INSERT [dbo].[Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (8, N'Jason', N'Franks', CAST(N'1975-12-05' AS Date), N'4028 Meadowbrook Mall Road', N'Los Angeles', N'CA', N'90046', N'Male', N'3108542553', N'jason.franks@gmail.com')
INSERT [dbo].[Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (9, N'Lauren', N'Hill', CAST(N'1994-10-31' AS Date), N'1943 Nickel Road', N'Los Angeles', N'CA', N'90017', N'Female', N'6266899895', N'lauren.hill@gmail.com')
INSERT [dbo].[Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (10, N'Peggy', N'Walcott', CAST(N'1987-08-04' AS Date), N'868 Bel Meadow Drive', N'Los Angeles', N'CA', N'90017', N'Female', N'9094325779', N'peggy.walcott@gmail.com')
INSERT [dbo].[Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (11, N'Shawn', N'Carter', CAST(N'1970-05-23' AS Date), N'4314 Lowndes Hill Park Road', N'Los Angeles', N'CA', N'90017', N'Male', N'6614645651', N'shawn.carter@gmail.com')
INSERT [dbo].[Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (12, N'Porsha', N'Gates', CAST(N'1964-02-11' AS Date), N'2137 Hilltop Haven Drive', N'Los Angeles', N'CA', N'90001', N'Female', N'9738781040', N'porsha.gates@gmail.com')
SET IDENTITY_INSERT [dbo].[Persons] OFF

SET IDENTITY_INSERT [dbo].[RegisteredStudents] ON 
INSERT [dbo].[RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (1, 1, 1)
INSERT [dbo].[RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (2, 2, 1)
INSERT [dbo].[RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (3, 3, 1)
INSERT [dbo].[RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (4, 4, 1)
INSERT [dbo].[RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (5, 5, 1)
INSERT [dbo].[RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (6, 6, 1)
INSERT [dbo].[RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (7, 2, 4)
INSERT [dbo].[RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (8, 4, 4)
INSERT [dbo].[RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (9, 6, 4)
INSERT [dbo].[RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (10, 1, 7)
INSERT [dbo].[RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (11, 3, 7)
INSERT [dbo].[RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (12, 5, 7)
SET IDENTITY_INSERT [dbo].[RegisteredStudents] OFF

INSERT [dbo].[Roles] ([roleID], [role]) VALUES (1, N'Student')
INSERT [dbo].[Roles] ([roleID], [role]) VALUES (2, N'Student')
INSERT [dbo].[Roles] ([roleID], [role]) VALUES (3, N'Student')
INSERT [dbo].[Roles] ([roleID], [role]) VALUES (4, N'Student')
INSERT [dbo].[Roles] ([roleID], [role]) VALUES (5, N'Student')
INSERT [dbo].[Roles] ([roleID], [role]) VALUES (6, N'Student')
INSERT [dbo].[Roles] ([roleID], [role]) VALUES (7, N'Teacher')
INSERT [dbo].[Roles] ([roleID], [role]) VALUES (8, N'Teacher')
INSERT [dbo].[Roles] ([roleID], [role]) VALUES (9, N'Teacher')
INSERT [dbo].[Roles] ([roleID], [role]) VALUES (10, N'Teacher')
INSERT [dbo].[Roles] ([roleID], [role]) VALUES (11, N'Administrator')
INSERT [dbo].[Roles] ([roleID], [role]) VALUES (12, N'Administrator')
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([studentID], [personID], [userID]) VALUES (1, 1, 1)
INSERT [dbo].[Students] ([studentID], [personID], [userID]) VALUES (2, 2, 2)
INSERT [dbo].[Students] ([studentID], [personID], [userID]) VALUES (3, 3, 3)
INSERT [dbo].[Students] ([studentID], [personID], [userID]) VALUES (4, 4, 4)
INSERT [dbo].[Students] ([studentID], [personID], [userID]) VALUES (5, 5, 5)
INSERT [dbo].[Students] ([studentID], [personID], [userID]) VALUES (6, 6, 6)
SET IDENTITY_INSERT [dbo].[Students] OFF

SET IDENTITY_INSERT [dbo].[TaughtCourses] ON 
INSERT [dbo].[TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (1, 1, 1)
INSERT [dbo].[TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (2, 1, 5)
INSERT [dbo].[TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (3, 1, 7)
INSERT [dbo].[TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (4, 2, 2)
INSERT [dbo].[TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (5, 2, 6)
INSERT [dbo].[TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (6, 2, 8)
INSERT [dbo].[TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (7, 3, 3)
INSERT [dbo].[TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (8, 4, 4)
SET IDENTITY_INSERT [dbo].[TaughtCourses] OFF

SET IDENTITY_INSERT [dbo].[Teachers] ON 
INSERT [dbo].[Teachers] ([teacherID], [personID], [userID]) VALUES (1, 7, 7)
INSERT [dbo].[Teachers] ([teacherID], [personID], [userID]) VALUES (2, 8, 8)
INSERT [dbo].[Teachers] ([teacherID], [personID], [userID]) VALUES (3, 9, 9)
INSERT [dbo].[Teachers] ([teacherID], [personID], [userID]) VALUES (4, 10, 10)
SET IDENTITY_INSERT [dbo].[Teachers] OFF

INSERT [dbo].[Users] ([userID], [userName], [password], [roleID]) VALUES (1, N'amy.stewart', N'amy', 1)
INSERT [dbo].[Users] ([userID], [userName], [password], [roleID]) VALUES (2, N'brett.jackson', N'brett', 2)
INSERT [dbo].[Users] ([userID], [userName], [password], [roleID]) VALUES (3, N'marcus.patterson', N'marcus', 3)
INSERT [dbo].[Users] ([userID], [userName], [password], [roleID]) VALUES (4, N'tammy.mann', N'tammy', 4)
INSERT [dbo].[Users] ([userID], [userName], [password], [roleID]) VALUES (5, N'richard.barnes', N'richard', 5)
INSERT [dbo].[Users] ([userID], [userName], [password], [roleID]) VALUES (6, N'mercedes.clarkson', N'mercedes', 6)
INSERT [dbo].[Users] ([userID], [userName], [password], [roleID]) VALUES (7, N'bob.monroe', N'bob', 7)
INSERT [dbo].[Users] ([userID], [userName], [password], [roleID]) VALUES (8, N'jason.franks', N'jason', 8)
INSERT [dbo].[Users] ([userID], [userName], [password], [roleID]) VALUES (9, N'lauren.hill', N'lauren', 9)
INSERT [dbo].[Users] ([userID], [userName], [password], [roleID]) VALUES (10, N'peggy.walcott', N'peggy', 10)
INSERT [dbo].[Users] ([userID], [userName], [password], [roleID]) VALUES (11, N'shawn.carter', N'shawn', 11)
INSERT [dbo].[Users] ([userID], [userName], [password], [roleID]) VALUES (12, N'porsha.gates', N'porsha', 12)

/****** Object:  Index [IX_Assignments]    Script Date: 6/17/2017 5:06:44 PM ******/
CREATE NONCLUSTERED INDEX [IX_Assignments] ON [dbo].[Assignments]
(
	[assignmentID] ASC
)

GO
ALTER TABLE [dbo].[Admins]  WITH CHECK ADD  CONSTRAINT [FK_Admins_Persons] FOREIGN KEY([personID])
REFERENCES [dbo].[Persons] ([personID])

GO
ALTER TABLE [dbo].[Admins] CHECK CONSTRAINT [FK_Admins_Persons]

GO
ALTER TABLE [dbo].[Admins]  WITH CHECK ADD  CONSTRAINT [FK_Admins_Users] FOREIGN KEY([userID])
REFERENCES [dbo].[Users] ([userID])

GO
ALTER TABLE [dbo].[Admins] CHECK CONSTRAINT [FK_Admins_Users]

GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Assignments_Categories1] FOREIGN KEY([categoryID])
REFERENCES [dbo].[Categories] ([categoryID])

GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_Assignments_Categories1]

GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_TaughtCourses] FOREIGN KEY([taughtCourseID])
REFERENCES [dbo].[TaughtCourses] ([taughtCourseID])

GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_TaughtCourses]

GO
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Credits] FOREIGN KEY([creditID])
REFERENCES [dbo].[Credits] ([creditID])

GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Credits]

GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Assignments] FOREIGN KEY([assignmentID])
REFERENCES [dbo].[Assignments] ([assignmentID])

GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_Assignments]

GO
ALTER TABLE [dbo].[Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_RegisteredStudents] FOREIGN KEY([registeredStudentID])
REFERENCES [dbo].[RegisteredStudents] ([registeredStudentID])

GO
ALTER TABLE [dbo].[Grades] CHECK CONSTRAINT [FK_Grades_RegisteredStudents]

GO
ALTER TABLE [dbo].[RegisteredStudents]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredStudents_Students] FOREIGN KEY([studentID])
REFERENCES [dbo].[Students] ([studentID])

GO
ALTER TABLE [dbo].[RegisteredStudents] CHECK CONSTRAINT [FK_RegisteredStudents_Students]

GO
ALTER TABLE [dbo].[RegisteredStudents]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredStudents_TaughtCourses] FOREIGN KEY([taughtCourseID])
REFERENCES [dbo].[TaughtCourses] ([taughtCourseID])

GO
ALTER TABLE [dbo].[RegisteredStudents] CHECK CONSTRAINT [FK_RegisteredStudents_TaughtCourses]

GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Persons] FOREIGN KEY([personID])
REFERENCES [dbo].[Persons] ([personID])

GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Persons]

GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Users] FOREIGN KEY([userID])
REFERENCES [dbo].[Users] ([userID])

GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Users]

GO
ALTER TABLE [dbo].[TaughtCourses]  WITH CHECK ADD  CONSTRAINT [FK_TaughtCourses_Courses] FOREIGN KEY([courseID])
REFERENCES [dbo].[Courses] ([courseID])
ON UPDATE CASCADE
ON DELETE CASCADE

GO
ALTER TABLE [dbo].[TaughtCourses] CHECK CONSTRAINT [FK_TaughtCourses_Courses]

GO
ALTER TABLE [dbo].[TaughtCourses]  WITH CHECK ADD  CONSTRAINT [FK_TaughtCourses_Teachers] FOREIGN KEY([teacherID])
REFERENCES [dbo].[Teachers] ([teacherID])
ON UPDATE CASCADE
ON DELETE CASCADE

GO
ALTER TABLE [dbo].[TaughtCourses] CHECK CONSTRAINT [FK_TaughtCourses_Teachers]

GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Persons] FOREIGN KEY([personID])
REFERENCES [dbo].[Persons] ([personID])

GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Persons]

GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Users] FOREIGN KEY([userID])
REFERENCES [dbo].[Users] ([userID])

GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Users]

GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([roleID])
REFERENCES [dbo].[Roles] ([roleID])

GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Roles]

GO

ALTER DATABASE [gradebook] SET  READ_WRITE 
GO
