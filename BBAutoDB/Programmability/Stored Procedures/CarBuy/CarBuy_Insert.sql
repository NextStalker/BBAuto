CREATE PROCEDURE [dbo].[CarBuy_Insert]
@idCar int, 
@idOwner int,
@idRegionBuy int,
@idRegionUsing int,
@idDriver int,
@dateOrder datetime,
@isGet int,
@dateGet nvarchar(50),
@cost float,
@dop nvarchar(100),
@events nvarchar(500),
@idDealer int
AS
BEGIN
	if (@idDealer = 0)
		SET @idDealer = 1
	
	Declare @count int
	SELECT @count=COUNT(car_id) FROM CarBuy WHERE car_id=@idCar
	
	if (@count = 0)
	begin
		INSERT INTO CarBuy VALUES(@idCar, @idOwner, @idRegionBuy, @idRegionUsing, @idDriver, @dateOrder,
			@isGet, @dateGet, @cost, @dop, @events, @idDealer)
	end
	else
	begin
		UPDATE CarBuy
		SET owner_id=@idOwner, region_id_buy=@idRegionBuy, region_id_using=@idRegionUsing,
			driver_id=@idDriver, carBuy_dateOrder=@dateOrder, carBuy_isGet=@isGet, carBuy_dateGet=@dateGet,
			carBuy_cost=@cost, carBuy_dop=@dop, carBuy_events=@events, dealerId=@idDealer
		WHERE car_id=@idCar
	end
END
GO
