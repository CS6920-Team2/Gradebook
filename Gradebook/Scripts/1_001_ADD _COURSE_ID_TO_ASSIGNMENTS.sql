DROP TABLE `Assignments`;
CREATE TABLE `Assignments` (
	`assignmentID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`courseID`	INTEGER,
	`categoryID`	INTEGER,
	`name`	nvarchar(50) NOT NULL,
	`description`	nvarchar(50) NOT NULL,
	`assignedDate`	datetime NOT NULL,
	`dueDate`	datetime NOT NULL,
	`possiblePoints`	INTEGER NOT NULL,
	FOREIGN KEY(`courseID`) REFERENCES `Courses`(`courseID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY(`categoryID`) REFERENCES `Categories`(`categoryID`) ON DELETE NO ACTION ON UPDATE NO ACTION
);

INSERT INTO [Assignments] ([assignmentID],[categoryID],[courseID],[name],[description],[assignedDate],[dueDate],[possiblePoints]) VALUES (
1,1,1,'Homework 1','Description 1','2017-06-12 00:00:00.000','2017-06-13 00:00:00.000',100);
INSERT INTO [Assignments] ([assignmentID],[categoryID],[courseID],[name],[description],[assignedDate],[dueDate],[possiblePoints]) VALUES (
2,1,1,'Homework 2','Description 2','2017-06-13 00:00:00.000','2017-06-14 00:00:00.000',100);
INSERT INTO [Assignments] ([assignmentID],[categoryID],[courseID],[name],[description],[assignedDate],[dueDate],[possiblePoints]) VALUES (
3,1,1,'Homework 3','Description 3','2017-06-14 00:00:00.000','2017-06-15 00:00:00.000',100);
INSERT INTO [Assignments] ([assignmentID],[categoryID],[courseID],[name],[description],[assignedDate],[dueDate],[possiblePoints]) VALUES (
4,2,1,'Project 1','Description 4','2017-06-15 00:00:00.000','2017-06-16 00:00:00.000',100);
INSERT INTO [Assignments] ([assignmentID],[categoryID],[courseID],[name],[description],[assignedDate],[dueDate],[possiblePoints]) VALUES (
5,3,1,'Attendance 1','Description 5','2017-06-12 00:00:00.000','2017-12-20 00:00:00.000',100);
INSERT INTO [Assignments] ([assignmentID],[categoryID],[courseID],[name],[description],[assignedDate],[dueDate],[possiblePoints]) VALUES (
6,4,1,'Test 1','Description 6','2017-06-16 00:00:00.000','2017-06-16 00:00:00.000',100);
INSERT INTO [Assignments] ([assignmentID],[categoryID],[courseID],[name],[description],[assignedDate],[dueDate],[possiblePoints]) VALUES (
7,5,1,'Participation','Description 7','2017-06-12 00:00:00.000','2017-12-20 00:00:00.000',100);