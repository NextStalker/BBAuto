CREATE PROCEDURE [dbo].[DTP_Select]
AS
BEGIN
	SELECT dtp_id, car_id, dtp_number, dtp_date, region_id, dtp_dateCallInsure, culprit_id, StatusAfterDTP_id,
		dtp_numberLoss, dtp_sum, dtp_damage, dtp_facts, dtp_comm, CurrentStatusAfterDTP_id
	FROM DTP
	WHERE YEAR(dtp_date) > 2013
END
GO
