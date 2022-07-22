namespace UMS.Application.Entities.Course.Commands.InsertCourse;
using UMS.Persistence;

public class InsertCourseHandler : MediatR.IRequestHandler<InsertCourseCommand, string>
{
    private readonly umsContext _context = new umsContext();
    public async Task<string> Handle(InsertCourseCommand request, CancellationToken cancellationToken)
    {
        //request.course.EnrolmentDateRange = _context.Courses.First().EnrolmentDateRange;
        var res = _context.Courses.AddAsync(request.course);
        var r=_context.SaveChanges();
        return "Course inserted";
        throw new NotImplementedException();
    }
}