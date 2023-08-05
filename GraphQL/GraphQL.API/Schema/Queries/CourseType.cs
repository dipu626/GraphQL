namespace GraphQL.API.Schema.Queries
{
    public enum Subject
    {
        Mathematics,
        Science,
        History
    }

    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }

        [GraphQLNonNullType]
        public InstructorType Instructor { get; set; }
        public IEnumerable<StudentType> Students { get; set; }

        [GraphQLDeprecated("This is for testing purpose if this works or not")]
        public string Desciption()
        {
            return $"{Name} - This is a course.";
        }
    }
}
