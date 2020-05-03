using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkAggregatorProject.Migrations
{
    public partial class spfnGetRateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"IF OBJECT_ID (N'dbo.fnGetRateUser', N'FN') IS NOT NULL  
                        DROP FUNCTION fnGetRateUser;  
                        GO  
                        CREATE FUNCTION dbo.fnGetRateUser(@userRate int, @linkId int)  
                        RETURNS int   
                        AS   
                        BEGIN  
                            DECLARE @ret int;  
                            SELECT @ret = ISNULL(r.IsRate, 0)
                            FROM Ratings r
                            WHERE r.UserId = @userRate   
                                AND r.LinkId = @linkId
                             IF (@ret IS NULL)   
                                SET @ret = 0;  
                            RETURN @ret;  
                        END; ";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
