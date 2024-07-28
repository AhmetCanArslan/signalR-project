using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
    public class TestiMonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialService;

        public TestiMonialManager(ITestimonialDal testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public void TAdd(Testimonial entity)
        {
            _testimonialService.Add(entity);
        }

        public void TDelete(Testimonial entity)
        {
            _testimonialService.Delete(entity);
        }

        public List<Testimonial> TGetAll()
        {
            return _testimonialService.GetAll();
        }

        public Testimonial TGetById(int id)
        {
            return _testimonialService.GetById(id);
        }

        public void TUpdate(Testimonial entity)
        {
            _testimonialService.Update(entity);
        }
    }
}
