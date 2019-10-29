using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Theory.Model;

namespace Theory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAnswersController : ControllerBase
    {
        private readonly TheoryContext _context;

        public StudentAnswersController(TheoryContext context)
        {
            _context = context;
        }

        // GET: api/StudentAnswers
        [HttpGet]
        public IEnumerable<StudentAnswers> GetStudentAnswers()
        {
            return _context.StudentAnswers;
        }

        // GET: api/StudentAnswers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentAnswers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentAnswers = await _context.StudentAnswers.FindAsync(id);

            if (studentAnswers == null)
            {
                return NotFound();
            }

            return Ok(studentAnswers);
        }

        // PUT: api/StudentAnswers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentAnswers([FromRoute] int id, [FromBody] StudentAnswers studentAnswers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentAnswers.id)
            {
                return BadRequest();
            }

            _context.Entry(studentAnswers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAnswersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentAnswers
        [HttpPost]
        public async Task<IActionResult> PostStudentAnswers([FromBody] StudentAnswers studentAnswers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StudentAnswers.Add(studentAnswers);

            //Getting into array before the algorithm

            string[] myAnswer = studentAnswers.Answers.Split(" ".ToCharArray());
            var dataExpected = _context.Questions.Where(q => q.Id == 1).FirstOrDefault();

            var quest = dataExpected.ExpectedAnswers.Split(" ".ToCharArray());


            int count = 0;
            foreach (string rem in myAnswer)
            {

                if (quest.Contains(rem))
                {
                    count += 1;
                }

            }

            Answer saveAnswer = new Answer
            {
                Ans = count.ToString(),
                MyQuestionsId = 2,  // _context.MyQuestions.Where(q => q.Id == 2).FirstOrDefault().Id
                StudentAnswersId = studentAnswers.id,
                StudentId = 1
            };

            _context.Answer.Add(saveAnswer);
            await _context.SaveChangesAsync();

            //This ends where the Answers are saved


            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentAnswers", new { id = studentAnswers.id }, studentAnswers);
        }

        // DELETE: api/StudentAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentAnswers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentAnswers = await _context.StudentAnswers.FindAsync(id);
            if (studentAnswers == null)
            {
                return NotFound();
            }

            _context.StudentAnswers.Remove(studentAnswers);
            await _context.SaveChangesAsync();

            return Ok(studentAnswers);
        }

        private bool StudentAnswersExists(int id)
        {
            return _context.StudentAnswers.Any(e => e.id == id);
        }
    }
}