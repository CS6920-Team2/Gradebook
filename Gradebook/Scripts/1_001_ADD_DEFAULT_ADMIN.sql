INSERT INTO [Users] ([userID],[userName],[password],[roleID],[resetPassword]) VALUES (
13,'admin','83FAEACAA189777DC154A43A502A7A73899DDB029C245777E454F1D7C25CA1D2',3,0);

INSERT INTO [Persons] ([personID],[firstName],[lastName],[dateOfBirth],[street],[city],[stateCode],[zipCode],[gender],[phoneNumber],[email]) VALUES (
13,'Admin','Admin','1964-02-11 00:00:00.000','2137 Hilltop Haven Drive','Los Angeles','CA','90001','Female','9738781040','porsha.gates@gmail.com');

INSERT INTO [Teachers] ([teacherID],[personID],[userID]) VALUES (
5,13,13);