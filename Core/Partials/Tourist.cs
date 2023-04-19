namespace Core.DataBase
{
    public partial class Tourist
    {
        public override string ToString()
        {
            return Patronymic != null ? $"{LastName} {FirstName[0]}. {Patronymic[0]}." : $"{LastName} {FirstName[0]}.";
        }
    }
}
