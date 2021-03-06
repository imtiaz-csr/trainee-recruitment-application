CREATE TABLE Batches
(
	BatchId INT IDENTITY PRIMARY KEY,
	BatchName NVARCHAR(50) NOT NULL
)
GO
CREATE TABLE Trainees                      
(
	TraineeId INT IDENTITY PRIMARY KEY,
	TraineeName NVARCHAR(30) NOT NULL,
	[Round] NVARCHAR(20) NOT NULL,
	Picture NVARCHAR(200) NOT NULL,
	BatchId INT NOT NULL REFERENCES Batches(BatchId)
)
GO
