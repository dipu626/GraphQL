﻿using Bogus;
using Bogus.Extensions;

namespace GraphQL.API.Schema.Queries
{
    public class Query
    {
        private readonly Faker<InstructorType> _instructorFaker;
        private readonly Faker<StudentType> _studentFaker;
        private readonly Faker<CourseType> _courseFaker;

        public Query()
        {
            _instructorFaker = new Faker<InstructorType>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Salary, f => Math.Round(f.Random.Double(0, 1000), 2));

            _studentFaker = new Faker<StudentType>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.GPA, f => Math.Round(f.Random.Double(1, 4), 2));

            _courseFaker = new Faker<CourseType>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.Name, f => f.Name.JobTitle())
                .RuleFor(c => c.Subject, f => f.PickRandom<Subject>())
                .RuleFor(c => c.Instructor, f => _instructorFaker.Generate())
                .RuleFor(c => c.Students, f => _studentFaker.Generate(3));
        }

        public IEnumerable<CourseType> GetCourses()
        {
            List<CourseType> fakeCourseTypes = _courseFaker.Generate(5);
            return fakeCourseTypes;
        }

        public async Task<CourseType> GetCourseTypeByIdAsync(Guid id)
        {
            await Task.FromResult(0);
            CourseType course = _courseFaker.Generate();
            course.Id = id;
            return course;
        }

        [GraphQLDeprecated("This query is deprecated")]
        public string Instructions => "Smash that like button and subscribe to SingletonSean";
    }
}
