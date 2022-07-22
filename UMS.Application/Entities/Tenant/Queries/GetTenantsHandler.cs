using MediatR;
using UMS.Application.Entities.Course.Queries.GetCourses;
using UMS.Persistence.Models;

namespace UMS.Application.Entities.Tenant.Queries;

public class GetTenantsHandler : IRequestHandler<GetTenantsQuery,List<Tenants>>
{
    private readonly umsContext _context = new umsContext();

    public async Task<List<Tenants>> Handle(GetTenantsQuery request, CancellationToken cancellationToken)
    {
        return _context.
    }
}

public class GetCoursesHandler : IRequestHandler<GetCoursesQuery,List<Domain.Models.Course>>
{
    private readonly umsContext _context = new umsContext();
    public async Task<List<Domain.Models.Course>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        return _context.Courses.ToList();
        throw new NotImplementedException();
    }
}