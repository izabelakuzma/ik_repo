using Microsoft.EntityFrameworkCore.Migrations;

namespace LinkAggregatorProject.Migrations
{
    public partial class spGetLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetLink]
                        @userRate int  = null,
	                    @userId int = null
                        AS
                        BEGIN
                        SET NOCOUNT ON;
                        if @userId is not null
                        BEGIN
                        SELECT l.LinkId, l.UserId , l.LinkAddress, l.Title,  l.AddingData, case when cast(r.IsRate as int) = 1 and r.UserId = @userRate
                        then 1 else 0 end as  IsRate 
                        , SUM(cast(ISNULL(r.IsRate, 0) as int)) OVER (PARTITION BY r.linkid) as Sum, r.RateId 
                        from Links l 
                        left join ratings r on l.LinkId = r.LinkId 
                        where l.UserId = @userId and cast(l.AddingData as date) >=  dateadd(DD, -5, cast(getdate() as date))
                        order by Sum desc 
                        END

                        ELSE
                        BEGIN
                        SELECT l.LinkId, l.UserId , l.LinkAddress, l.Title,  l.AddingData, case when cast(r.IsRate as int) = 1 and r.UserId = @userRate
                        then 1 else 0 end as  IsRate
                        , SUM(cast(ISNULL(r.IsRate, 0) as int)) OVER (PARTITION BY r.linkid) as Sum, r.RateId
                        from Links l 
                        left join ratings r
                        on l.LinkId = r.LinkId 
                        where cast(l.AddingData as date) >=  dateadd(DD, -5, cast(getdate() as date))
                        order by Sum desc 
                        END

                        END";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
