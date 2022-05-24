namespace Domain.Configurations;

public class AppUserConfig : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        //builder.HasData(new AppUser()
        //{
        //    Id = 1,
        //    Email = "test@tst.com",
        //    UserName = "test",
            
        //});
    }
}