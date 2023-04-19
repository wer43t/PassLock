namespace Core.DataBase
{
    public partial class User
    {
        public override string ToString()
        {
            return $"{LastName} {FirstName[0]}.";
        }
    }
}
