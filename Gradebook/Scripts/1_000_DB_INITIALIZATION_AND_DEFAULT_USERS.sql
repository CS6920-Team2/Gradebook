USE [gradebook]
GO
/****** Object:  Table [Admins]    Script Date: 6/15/2017 11:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Admins](
	[adminID] [int] IDENTITY(1,1) NOT NULL,
	[personID] [int] NOT NULL,
	[userID] [int] NOT NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[adminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Assignments]    Script Date: 6/15/2017 11:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Assignments](
	[assignmentID] [int] IDENTITY(1,1) NOT NULL,
	[categoryID] [int] NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](50) NOT NULL,
	[assignedDate] [date] NOT NULL,
	[dueDate] [date] NOT NULL,
	[possiblePoints] [int] NOT NULL,
 CONSTRAINT [PK_Assignments_1] PRIMARY KEY CLUSTERED 
(
	[assignmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Categories]    Script Date: 6/15/2017 11:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Categories](
	[categoryID] [int] IDENTITY(1,1) NOT NULL,
	[taughtCourseID] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[weight] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[categoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Courses]    Script Date: 6/15/2017 11:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Courses](
	[courseID] [int] IDENTITY(1,1) NOT NULL,
	[creditID] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[courseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Credits]    Script Date: 6/15/2017 11:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Credits](
	[creditID] [int] IDENTITY(1,1) NOT NULL,
	[type] [varchar](50) NOT NULL,
	[months] [int] NOT NULL,
 CONSTRAINT [PK_Divisions] PRIMARY KEY CLUSTERED 
(
	[creditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Grades]    Script Date: 6/15/2017 11:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Grades](
	[gradeID] [int] IDENTITY(1,1) NOT NULL,
	[registeredStudentID] [int] NOT NULL,
	[assignmentID] [int] NOT NULL,
	[actualPoints] [int] NOT NULL,
	[comment] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED 
(
	[gradeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Persons]    Script Date: 6/15/2017 11:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Persons](
	[personID] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](50) NOT NULL,
	[lastName] [varchar](50) NOT NULL,
	[dateOfBirth] [date] NULL,
	[street] [varchar](50) NULL,
	[city] [varchar](50) NULL,
	[stateCode] [char](2) NULL,
	[zipCode] [char](5) NULL,
	[gender] [varchar](50) NULL,
	[phoneNumber] [varchar](50) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[personID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [RegisteredStudents]    Script Date: 6/15/2017 11:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [RegisteredStudents](
	[registeredStudentID] [int] IDENTITY(1,1) NOT NULL,
	[studentID] [int] NOT NULL,
	[taughtCourseID] [int] NOT NULL,
 CONSTRAINT [PK_RegisteredStudents] PRIMARY KEY CLUSTERED 
(
	[registeredStudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Roles]    Script Date: 6/15/2017 11:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Roles](
	[roleID] [int] NOT NULL,
	[role] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[roleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Students]    Script Date: 6/15/2017 11:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Students](
	[studentID] [int] IDENTITY(1,1) NOT NULL,
	[personID] [int] NOT NULL,
	[userID] [int] NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [TaughtCourses]    Script Date: 6/15/2017 11:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TaughtCourses](
	[taughtCourseID] [int] IDENTITY(1,1) NOT NULL,
	[teacherID] [int] NOT NULL,
	[courseID] [int] NOT NULL,
 CONSTRAINT [PK_TaughtCourses] PRIMARY KEY CLUSTERED 
(
	[taughtCourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Teachers]    Script Date: 6/15/2017 11:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Teachers](
	[teacherID] [int] IDENTITY(1,1) NOT NULL,
	[personID] [int] NOT NULL,
	[userID] [int] NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[teacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [Users]    Script Date: 6/15/2017 11:08:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Users](
	[userID] [int] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[roleID] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [Admins] ON 

INSERT [Admins] ([adminID], [personID], [userID]) VALUES (1, 11, 11)
INSERT [Admins] ([adminID], [personID], [userID]) VALUES (2, 12, 12)
SET IDENTITY_INSERT [Admins] OFF
SET IDENTITY_INSERT [Assignments] ON 

INSERT [Assignments] ([assignmentID], [categoryID], [name], [description], [assignedDate], [dueDate], [possiblePoints]) VALUES (1, 1, N'Homework 1', N'Description 1', CAST(N'2017-06-12' AS Date), CAST(N'2017-06-13' AS Date), 100)
INSERT [Assignments] ([assignmentID], [categoryID], [name], [description], [assignedDate], [dueDate], [possiblePoints]) VALUES (2, 1, N'Homework 2', N'Description 2', CAST(N'2017-06-13' AS Date), CAST(N'2017-06-14' AS Date), 100)
INSERT [Assignments] ([assignmentID], [categoryID], [name], [description], [assignedDate], [dueDate], [possiblePoints]) VALUES (3, 1, N'Homework 3', N'Description 3', CAST(N'2017-06-14' AS Date), CAST(N'2017-06-15' AS Date), 100)
INSERT [Assignments] ([assignmentID], [categoryID], [name], [description], [assignedDate], [dueDate], [possiblePoints]) VALUES (4, 2, N'Project 1', N'Description 4', CAST(N'2017-06-15' AS Date), CAST(N'2017-06-16' AS Date), 100)
INSERT [Assignments] ([assignmentID], [categoryID], [name], [description], [assignedDate], [dueDate], [possiblePoints]) VALUES (5, 3, N'Attendance 1', N'Description 5', CAST(N'2017-06-12' AS Date), CAST(N'2017-12-20' AS Date), 100)
INSERT [Assignments] ([assignmentID], [categoryID], [name], [description], [assignedDate], [dueDate], [possiblePoints]) VALUES (6, 4, N'Test 1', N'Description 6', CAST(N'2017-06-16' AS Date), CAST(N'2017-06-16' AS Date), 100)
INSERT [Assignments] ([assignmentID], [categoryID], [name], [description], [assignedDate], [dueDate], [possiblePoints]) VALUES (7, 5, N'Participation', N'Description 7', CAST(N'2017-06-12' AS Date), CAST(N'2017-12-20' AS Date), 100)
SET IDENTITY_INSERT [Assignments] OFF
SET IDENTITY_INSERT [Categories] ON 

INSERT [Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (1, 1, N'Homework', 20)
INSERT [Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (2, 1, N'Project', 20)
INSERT [Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (3, 1, N'Attendance', 20)
INSERT [Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (4, 1, N'Test', 20)
INSERT [Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (5, 1, N'Participation', 20)
INSERT [Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (6, 4, N'Homework', 50)
INSERT [Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (7, 4, N'Project', 50)
INSERT [Categories] ([categoryID], [taughtCourseID], [name], [weight]) VALUES (8, 7, N'Project', 100)
SET IDENTITY_INSERT [Categories] OFF
SET IDENTITY_INSERT [Courses] ON 

INSERT [Courses] ([courseID], [creditID], [name], [description]) VALUES (1, 2, N'Math', N'Math Semester')
INSERT [Courses] ([courseID], [creditID], [name], [description]) VALUES (2, 2, N'English', N'English Semester')
INSERT [Courses] ([courseID], [creditID], [name], [description]) VALUES (3, 2, N'Science', N'Science Semester')
INSERT [Courses] ([courseID], [creditID], [name], [description]) VALUES (4, 2, N'History', N'History Semester')
INSERT [Courses] ([courseID], [creditID], [name], [description]) VALUES (5, 1, N'Math', N'Math Quarter')
INSERT [Courses] ([courseID], [creditID], [name], [description]) VALUES (6, 1, N'English', N'English Quarter')
INSERT [Courses] ([courseID], [creditID], [name], [description]) VALUES (7, 3, N'Math', N'Math Term')
INSERT [Courses] ([courseID], [creditID], [name], [description]) VALUES (8, 3, N'English', N'English Term')
SET IDENTITY_INSERT [Courses] OFF
SET IDENTITY_INSERT [Credits] ON 

INSERT [Credits] ([creditID], [type], [months]) VALUES (1, N'Quarter', 3)
INSERT [Credits] ([creditID], [type], [months]) VALUES (2, N'Semester', 4)
INSERT [Credits] ([creditID], [type], [months]) VALUES (3, N'Term', 6)
SET IDENTITY_INSERT [Credits] OFF
SET IDENTITY_INSERT [Grades] ON 

INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (1, 1, 1, 90, N'A')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (2, 2, 1, 80, N'B-')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (3, 3, 1, 79, N'C+')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (4, 4, 1, 75, N'C')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (5, 5, 1, 60, N'D-')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (6, 6, 1, 50, N'F-')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (7, 1, 2, 85, N'B')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (8, 2, 2, 100, N'A+')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (9, 3, 2, 80, N'B')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (10, 4, 2, 70, N'C-')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (11, 5, 2, 75, N'C')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (12, 6, 2, 90, N'A-')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (13, 1, 3, 100, N'A+')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (14, 2, 3, 100, N'A+')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (15, 3, 3, 100, N'A+')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (16, 4, 3, 100, N'A+')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (17, 5, 3, 100, N'A+')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (18, 6, 3, 100, N'A+')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (19, 1, 4, 80, N'B-')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (20, 2, 4, 70, N'C-')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (21, 3, 4, 75, N'C')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (22, 4, 4, 85, N'B+')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (23, 5, 4, 90, N'A-')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (24, 6, 4, 100, N'A+')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (25, 1, 5, 90, N'A-')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (26, 2, 5, 90, N'A-')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (27, 3, 5, 90, N'A-')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (28, 4, 5, 90, N'A-')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (29, 5, 5, 90, N'A-')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (30, 6, 5, 90, N'A-')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (31, 1, 6, 95, N'A')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (32, 2, 6, 95, N'A')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (33, 3, 6, 95, N'A')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (34, 4, 6, 95, N'A')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (35, 5, 6, 95, N'A')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (36, 6, 6, 95, N'A')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (37, 1, 7, 100, N'A+')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (38, 2, 7, 100, N'A+')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (39, 3, 7, 100, N'A+')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (40, 4, 7, 100, N'A+')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (41, 5, 7, 100, N'A+')
INSERT [Grades] ([gradeID], [registeredStudentID], [assignmentID], [actualPoints], [comment]) VALUES (42, 6, 7, 100, N'A+')
SET IDENTITY_INSERT [Grades] OFF
SET IDENTITY_INSERT [Persons] ON 

INSERT [Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (1, N'Amy', N'Stewart', CAST(N'2005-02-17' AS Date), N'4417 Brannon Street', N'Los Angeles', N'CA', N'90017', N'Female', N'8053223938', N'amy.stewart@gmail.com')
INSERT [Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (2, N'Brett', N'Jackson', CAST(N'2004-04-11' AS Date), N'2479 New York Avenue', N'Los Angeles', N'CA', N'90071', N'Male', N'8182106232', N'brett.jackson@gmail.com')
INSERT [Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (3, N'Marcus', N'Patterson', CAST(N'2003-06-12' AS Date), N'4003 Brannon Street', N'Los Angeles', N'CA', N'90017', N'Male', N'2132886979', N'marcus.patterson@gmail.com')
INSERT [Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (4, N'Tammy', N'Mann', CAST(N'2004-01-31' AS Date), N'265 Evergreen Lane', N'Los Angeles', N'CA', N'90036', N'Female', N'3235490398', N'tammy.mann@gmail.com')
INSERT [Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (5, N'Richard', N'Barnes', CAST(N'2005-03-05' AS Date), N'4528 Southside Lane', N'Los Angeles', N'CA', N'90045', N'Male', N'3237765995', N'richard.barnes@gmail.com')
INSERT [Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (6, N'Mercedes', N'Clarkson', CAST(N'2003-02-01' AS Date), N'98 Felosa Drive', N'Los Angeles', N'CA', N'90017', N'Female', N'3239617644', N'mercedes.clarkson@gmail.com')
INSERT [Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (7, N'Bob', N'Monroe', CAST(N'1982-10-01' AS Date), N'
4366 Glendale Avenue
', N'Los Angeles', N'CA', N'90017', N'Male', N'8186803264', N'bob.monroe@gmail.com')
INSERT [Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (8, N'Jason', N'Franks', CAST(N'1975-12-05' AS Date), N'4028 Meadowbrook Mall Road', N'Los Angeles', N'CA', N'90046', N'Male', N'3108542553', N'jason.franks@gmail.com')
INSERT [Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (9, N'Lauren', N'Hill', CAST(N'1994-10-31' AS Date), N'1943 Nickel Road', N'Los Angeles', N'CA', N'90017', N'Female', N'6266899895', N'lauren.hill@gmail.com')
INSERT [Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (10, N'Peggy', N'Walcott', CAST(N'1987-08-04' AS Date), N'868 Bel Meadow Drive', N'Los Angeles', N'CA', N'90017', N'Female', N'9094325779', N'peggy.walcott@gmail.com')
INSERT [Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (11, N'Shawn', N'Carter', CAST(N'1970-05-23' AS Date), N'4314 Lowndes Hill Park Road', N'Los Angeles', N'CA', N'90017', N'Male', N'6614645651', N'shawn.carter@gmail.com')
INSERT [Persons] ([personID], [firstName], [lastName], [dateOfBirth], [street], [city], [stateCode], [zipCode], [gender], [phoneNumber], [email]) VALUES (12, N'Porsha', N'Gates', CAST(N'1964-02-11' AS Date), N'2137 Hilltop Haven Drive', N'Los Angeles', N'CA', N'90001', N'Female', N'9738781040', N'porsha.gates@gmail.com')
SET IDENTITY_INSERT [Persons] OFF
SET IDENTITY_INSERT [RegisteredStudents] ON 

INSERT [RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (1, 1, 1)
INSERT [RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (2, 2, 1)
INSERT [RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (3, 3, 1)
INSERT [RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (4, 4, 1)
INSERT [RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (5, 5, 1)
INSERT [RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (6, 6, 1)
INSERT [RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (7, 2, 4)
INSERT [RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (8, 4, 4)
INSERT [RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (9, 6, 4)
INSERT [RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (10, 1, 7)
INSERT [RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (11, 3, 7)
INSERT [RegisteredStudents] ([registeredStudentID], [studentID], [taughtCourseID]) VALUES (12, 5, 7)
SET IDENTITY_INSERT [RegisteredStudents] OFF
INSERT [Roles] ([roleID], [role]) VALUES (1, N'Student')
INSERT [Roles] ([roleID], [role]) VALUES (2, N'Student')
INSERT [Roles] ([roleID], [role]) VALUES (3, N'Student')
INSERT [Roles] ([roleID], [role]) VALUES (4, N'Student')
INSERT [Roles] ([roleID], [role]) VALUES (5, N'Student')
INSERT [Roles] ([roleID], [role]) VALUES (6, N'Student')
INSERT [Roles] ([roleID], [role]) VALUES (7, N'Teacher')
INSERT [Roles] ([roleID], [role]) VALUES (8, N'Teacher')
INSERT [Roles] ([roleID], [role]) VALUES (9, N'Teacher')
INSERT [Roles] ([roleID], [role]) VALUES (10, N'Teacher')
INSERT [Roles] ([roleID], [role]) VALUES (11, N'Administrator')
INSERT [Roles] ([roleID], [role]) VALUES (12, N'Administrator')
SET IDENTITY_INSERT [Students] ON 

INSERT [Students] ([studentID], [personID], [userID]) VALUES (1, 1, 1)
INSERT [Students] ([studentID], [personID], [userID]) VALUES (2, 2, 2)
INSERT [Students] ([studentID], [personID], [userID]) VALUES (3, 3, 3)
INSERT [Students] ([studentID], [personID], [userID]) VALUES (4, 4, 4)
INSERT [Students] ([studentID], [personID], [userID]) VALUES (5, 5, 5)
INSERT [Students] ([studentID], [personID], [userID]) VALUES (6, 6, 6)
SET IDENTITY_INSERT [Students] OFF
SET IDENTITY_INSERT [TaughtCourses] ON 

INSERT [TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (1, 1, 1)
INSERT [TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (2, 1, 5)
INSERT [TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (3, 1, 7)
INSERT [TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (4, 2, 2)
INSERT [TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (5, 2, 6)
INSERT [TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (6, 2, 8)
INSERT [TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (7, 3, 3)
INSERT [TaughtCourses] ([taughtCourseID], [teacherID], [courseID]) VALUES (8, 4, 4)
SET IDENTITY_INSERT [TaughtCourses] OFF
SET IDENTITY_INSERT [Teachers] ON 

INSERT [Teachers] ([teacherID], [personID], [userID]) VALUES (1, 7, 7)
INSERT [Teachers] ([teacherID], [personID], [userID]) VALUES (2, 8, 8)
INSERT [Teachers] ([teacherID], [personID], [userID]) VALUES (3, 9, 9)
INSERT [Teachers] ([teacherID], [personID], [userID]) VALUES (4, 10, 10)
SET IDENTITY_INSERT [Teachers] OFF
INSERT [Users] ([userID], [userName], [password], [roleID]) VALUES (1, N'amy.stewart', N'amy', 1)
INSERT [Users] ([userID], [userName], [password], [roleID]) VALUES (2, N'brett.jackson', N'brett', 2)
INSERT [Users] ([userID], [userName], [password], [roleID]) VALUES (3, N'marcus.patterson', N'marcus', 3)
INSERT [Users] ([userID], [userName], [password], [roleID]) VALUES (4, N'tammy.mann', N'tammy', 4)
INSERT [Users] ([userID], [userName], [password], [roleID]) VALUES (5, N'richard.barnes', N'richard', 5)
INSERT [Users] ([userID], [userName], [password], [roleID]) VALUES (6, N'mercedes.clarkson', N'mercedes', 6)
INSERT [Users] ([userID], [userName], [password], [roleID]) VALUES (7, N'bob.monroe', N'bob', 7)
INSERT [Users] ([userID], [userName], [password], [roleID]) VALUES (8, N'jason.franks', N'jason', 8)
INSERT [Users] ([userID], [userName], [password], [roleID]) VALUES (9, N'lauren.hill', N'lauren', 9)
INSERT [Users] ([userID], [userName], [password], [roleID]) VALUES (10, N'peggy.walcott', N'peggy', 10)
INSERT [Users] ([userID], [userName], [password], [roleID]) VALUES (11, N'shawn.carter', N'shawn', 11)
INSERT [Users] ([userID], [userName], [password], [roleID]) VALUES (12, N'porsha.gates', N'porsha', 12)
/****** Object:  Index [IX_Assignments]    Script Date: 6/15/2017 11:08:09 PM ******/
CREATE NONCLUSTERED INDEX [IX_Assignments] ON [Assignments]
(
	[assignmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Users]    Script Date: 6/15/2017 11:08:09 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users] ON [Users]
(
	[userName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [Admins]  WITH CHECK ADD  CONSTRAINT [FK_Admins_Persons] FOREIGN KEY([personID])
REFERENCES [Persons] ([personID])
GO
ALTER TABLE [Admins] CHECK CONSTRAINT [FK_Admins_Persons]
GO
ALTER TABLE [Admins]  WITH CHECK ADD  CONSTRAINT [FK_Admins_Users] FOREIGN KEY([userID])
REFERENCES [Users] ([userID])
GO
ALTER TABLE [Admins] CHECK CONSTRAINT [FK_Admins_Users]
GO
ALTER TABLE [Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Assignments_Categories1] FOREIGN KEY([categoryID])
REFERENCES [Categories] ([categoryID])
GO
ALTER TABLE [Assignments] CHECK CONSTRAINT [FK_Assignments_Categories1]
GO
ALTER TABLE [Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_TaughtCourses] FOREIGN KEY([taughtCourseID])
REFERENCES [TaughtCourses] ([taughtCourseID])
GO
ALTER TABLE [Categories] CHECK CONSTRAINT [FK_Categories_TaughtCourses]
GO
ALTER TABLE [Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Credits] FOREIGN KEY([creditID])
REFERENCES [Credits] ([creditID])
GO
ALTER TABLE [Courses] CHECK CONSTRAINT [FK_Courses_Credits]
GO
ALTER TABLE [Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_Assignments] FOREIGN KEY([assignmentID])
REFERENCES [Assignments] ([assignmentID])
GO
ALTER TABLE [Grades] CHECK CONSTRAINT [FK_Grades_Assignments]
GO
ALTER TABLE [Grades]  WITH CHECK ADD  CONSTRAINT [FK_Grades_RegisteredStudents] FOREIGN KEY([registeredStudentID])
REFERENCES [RegisteredStudents] ([registeredStudentID])
GO
ALTER TABLE [Grades] CHECK CONSTRAINT [FK_Grades_RegisteredStudents]
GO
ALTER TABLE [RegisteredStudents]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredStudents_Students] FOREIGN KEY([studentID])
REFERENCES [Students] ([studentID])
GO
ALTER TABLE [RegisteredStudents] CHECK CONSTRAINT [FK_RegisteredStudents_Students]
GO
ALTER TABLE [RegisteredStudents]  WITH CHECK ADD  CONSTRAINT [FK_RegisteredStudents_TaughtCourses] FOREIGN KEY([taughtCourseID])
REFERENCES [TaughtCourses] ([taughtCourseID])
GO
ALTER TABLE [RegisteredStudents] CHECK CONSTRAINT [FK_RegisteredStudents_TaughtCourses]
GO
ALTER TABLE [Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Persons] FOREIGN KEY([personID])
REFERENCES [Persons] ([personID])
GO
ALTER TABLE [Students] CHECK CONSTRAINT [FK_Students_Persons]
GO
ALTER TABLE [Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Users] FOREIGN KEY([userID])
REFERENCES [Users] ([userID])
GO
ALTER TABLE [Students] CHECK CONSTRAINT [FK_Students_Users]
GO
ALTER TABLE [TaughtCourses]  WITH CHECK ADD  CONSTRAINT [FK_TaughtCourses_Courses] FOREIGN KEY([courseID])
REFERENCES [Courses] ([courseID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [TaughtCourses] CHECK CONSTRAINT [FK_TaughtCourses_Courses]
GO
ALTER TABLE [TaughtCourses]  WITH CHECK ADD  CONSTRAINT [FK_TaughtCourses_Teachers] FOREIGN KEY([teacherID])
REFERENCES [Teachers] ([teacherID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [TaughtCourses] CHECK CONSTRAINT [FK_TaughtCourses_Teachers]
GO
ALTER TABLE [Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Persons] FOREIGN KEY([personID])
REFERENCES [Persons] ([personID])
GO
ALTER TABLE [Teachers] CHECK CONSTRAINT [FK_Teachers_Persons]
GO
ALTER TABLE [Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Users] FOREIGN KEY([userID])
REFERENCES [Users] ([userID])
GO
ALTER TABLE [Teachers] CHECK CONSTRAINT [FK_Teachers_Users]
GO
ALTER TABLE [Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([roleID])
REFERENCES [Roles] ([roleID])
GO
ALTER TABLE [Users] CHECK CONSTRAINT [FK_Users_Roles]
GO
ALTER DATABASE [gradebook] SET  READ_WRITE 
GO
