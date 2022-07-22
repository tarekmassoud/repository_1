namespace UMS.Application.Entities.Course.Commands.InsertCourse;
using MediatR;

public class InsertCourseCommand : IRequest<string>
{
    public UMS.Domain.Models.Course course;

    public InsertCourseCommand(Domain.Models.Course course)
    {
        this.course = course;
    }
}