using AutoMapper;
using Proiect.Data;
using Proiect.Interface;
using Proiect.Models;

namespace Proiect.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ReviewRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateReview(Review review)
        {
            _context.Add(review);
            return Save();
        }

        public bool CreateReviewer(Reviewer reviewer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteReview(Review review)
        {
            _context.Remove(review);
            return Save();
        }

        public bool DeleteReviewer(Reviewer reviewer)
        {
            throw new NotImplementedException();
        }

        public bool DeleteReviews(List<Review> reviews)
        {
            _context.RemoveRange(reviews);
            return Save();
        }

        public Review GetReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public Reviewer GetReviewer(int reviewerId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            throw new NotImplementedException();
        }

        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Review> GetReviewsOfAnApartment(int pokeId)
        {
            return _context.Reviews.Where(r => r.Apartment.Id == pokeId).ToList();
        }

        public bool ReviewerExists(int reviewerId)
        {
            throw new NotImplementedException();
        }

        public bool ReviewExists(int reviewId)
        {
            return _context.Reviews.Any(r => r.Id == reviewId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReview(Review review)
        {
            _context.Update(review);
            return Save();
        }

        public bool UpdateReviewer(Reviewer reviewer)
        {
            throw new NotImplementedException();
        }
    }
}
