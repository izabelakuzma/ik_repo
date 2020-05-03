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
                        IF @userId IS NOT NULL
                        BEGIN
                        SELECT DISTINCT l.LinkId, l.UserId , l.LinkAddress, l.Title,  l.AddingData, case when cast(r.IsRate as int) = 1 and r.UserId = @userRate
                        then 1 else 0 end as  IsRate 
                        , SUM(cast(ISNULL(r.IsRate, 0) as int)) OVER (PARTITION BY r.linkid) as Sum
                        from Links l 
                        left join ratings r on l.LinkId = r.LinkId 
                        where l.UserId = @userId and cast(l.AddingData as date) >=  dateadd(DD, -5, cast(getdate() as date))
                        order by Sum desc 
                        END

                        ELSE
                        BEGIN
                         SELECT DISTINCT l.LinkId, l.UserId , l.LinkAddress, l.Title,  l.AddingData, dbo.fnGetRateUser(@userRate, r.LinkId) as  IsRate
                        , SUM(cast(ISNULL(r.IsRate, 0) as int)) OVER (PARTITION BY r.linkid) as Sum
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
