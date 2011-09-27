using System.Data;
using Migrator.Framework;

namespace NuGetGallery {
    [Migration(20110919211100)]
    public class CreatePackageOwnerRequestTable : Migration {
        public override void Up() {
            Database.AddTable("PackageOwnerRequests",
                new Column("[Key]", DbType.Int32, ColumnProperty.PrimaryKey | ColumnProperty.Identity | ColumnProperty.NotNull),
                new Column("PackageRegistrationKey", DbType.Int32, ColumnProperty.NotNull),
                new Column("NewOwnerKey", DbType.Int32, ColumnProperty.NotNull),
                new Column("RequestingOwnerKey", DbType.Int32, ColumnProperty.NotNull),
                new Column("ConfirmationCode", DbType.String, 64, ColumnProperty.NotNull),
                new Column("RequestDate", DbType.DateTime, ColumnProperty.NotNull));

            Database.AddForeignKey("FK_PackageOwnerRequests_PackageRegistrations", "PackageOwnerRequests", "PackageRegistrationKey", "PackageRegistrations", "[Key]");
            Database.AddForeignKey("FK_PackageOwnerRequests_Users", "PackageOwnerRequests", "NewOwnerKey", "Users", "[Key]");

        }

        public override void Down() {
            Database.RemoveTable("PackageOwnerRequests");
        }
    }
}
