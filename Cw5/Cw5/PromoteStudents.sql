CREATE PROCEDURE PromoteStudents @Studies NVARCHAR(100), @Semester INT
AS
BEGIN
	SET XACT_ABORT ON;
	BEGIN TRANSACTION
	
	DECLARE @IdStudies INT = (SELECT IdStudies FROM Studies WHERE Name = @Studies))
	DECLARE @IdEnrollment INT = (SELECT IdEnrollment FROM Studies WHERE Name = @Studies))
	
	IF @IdStudies IS NULL
	BEGIN
		RAISE_APPLICATION_ERROR("Blad brak ID studenta");
		ROLLBACK;
	END;
	IF @IdEnrollment IS NULL
	BEGIN
		RAISE_APPLICATION_ERROR("Blad brak ID rekrutacji");
		ROLLBACK;
	END;
	
	INSERT INTO Enrollment (IdEnrollment, Semester, IdStudies, StartDate) VALUES (@IdEnrollment, @Semester + 1, @IdStudies, GETDATE());
	COMMIT;
END;