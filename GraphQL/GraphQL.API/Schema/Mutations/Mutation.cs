namespace GraphQL.API.Schema.Mutations
{
    public class Mutation
    {
        private readonly List<CourseResult> _courses;

        public Mutation()
        {
            if (this._courses == null)
            {
                _courses = new List<CourseResult>();
            }
        }

        public CourseResult CreateCourse(CourseInputType courseInputType)
        {
            CourseResult courseResult = new()
            {
                Id = Guid.NewGuid(),
                Name = courseInputType.Name,
                Subject = courseInputType.Subject,
                InstructorId = courseInputType.InstructorId
            };

            _courses.Add(courseResult);

            return courseResult;
        }

        public CourseResult UpdateCourse(Guid courseId, CourseInputType courseInputType)
        {
            CourseResult? course = _courses.FirstOrDefault(it => it.Id == courseId)
                ?? throw new GraphQLException(new Error(message: "Course not found!!!", code: "COURSE_NOT_FOUND"));
            course.Name = courseInputType.Name;
            course.Subject = courseInputType.Subject;
            course.InstructorId = courseInputType.InstructorId;

            return course;
        }

        public bool DeleteCourse(Guid courseId)
        {
            return _courses.RemoveAll(it => it.Id == courseId) >= 1;
        }
    }
}
