using GraphQL.Types;

public class EmployeeInputType : InputObjectGraphType
{
    public EmployeeInputType()
    {
        Name = "EmployeeInput";
        Field<NonNullGraphType<StringGraphType>>("name");
    }
}
