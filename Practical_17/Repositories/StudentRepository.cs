﻿using Microsoft.EntityFrameworkCore;
using Practical_17.Data;
using Practical_17.Models;
using Practical_17.Services;

namespace Practical_17.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync() =>
            await _context.Students.ToListAsync();

        public async Task<Student> GetByIdAsync(int id) =>
            await _context.Students.FindAsync(id);

        public async Task AddAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }

}
