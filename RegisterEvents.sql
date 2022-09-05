CREATE PROCEDURE sp_RegisterInstitute(
@Institute_name varchar(100),
@Institute_address varchar(100),
@Students_Number int,
@Time_service int,
@Price int,
@Message varchar(100) output
)
as
begin
	INSERT INTO INSTITUTE(Institute_name,Institute_address,Students_Number,Time_service, Price) VALUES (@Institute_name,@Institute_address,@Students_Number, @Time_service, @Price)
	SET @Message = 'Registered institute'
end

declare @messages varchar(100)
exec sp_RegisterInstitute 'prueba', 'cra 8 # 3 - 2', 20, 12, 1200, @messages output

select @messages

select * from dbo.INSTITUTE