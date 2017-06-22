CREATE TABLE [Admins] ( 
[adminID] integer PRIMARY KEY AUTOINCREMENT NOT NULL, 
[personID] integer NOT NULL, 
[userID] integer , 
FOREIGN KEY ([personID]) REFERENCES [Persons]([personID]), 
FOREIGN KEY ([userID]) REFERENCES [Users]([userID]) 
)

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