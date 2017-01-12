using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTest.Models;

namespace OnlineTest.Controllers
{
    public class TestHistoryController : Controller
    {
        private TestHistoryDBContext db = new TestHistoryDBContext();
        private QuestionDBContext question = new QuestionDBContext();
        List<Question> RandomQuestionList = new List<Question>();
        Random rand = new Random();
        int index = 0;
        public  int numberOfQuestion = 5;
        private int score = 0;

        //
        // GET: /TestHistory/

        public ActionResult Index()
        {
            return View(db.TestHistorys.ToList());
        }

        // GET: /Questions/StartTest

        public ActionResult StartTest()
        {
            TempData["value"] = 0;
            List<Question> listOfQuestion = question.Questions.ToList();
            for (int count = 0; count < numberOfQuestion; count++)
            {
                int randomIndex = rand.Next(listOfQuestion.Count);
                RandomQuestionList.Add(listOfQuestion[randomIndex]);
            }
            Question getquestion = GetQuestion();
            return View(getquestion);
        }
        
        public Question GetQuestion()
        {
            Question Question = new Question();
            if (index < 5)
            {
                Question = RandomQuestionList[index];
            }
            index++;
            return Question;
        }

        //Validate

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string StartTest(FormCollection postedForm, Question Ques)
        {
            string result = "";

            if (postedForm[Ques.Option1].ToString().Contains("true"))
            {
                result = result + " " + Ques.Option1;
            }
            else if (postedForm[Ques.Option2].ToString().Contains("true"))
            {
                result = result + " " + Ques.Option2;
            }
            else if (postedForm[Ques.Option3].ToString().Contains("true"))
            {
                result = result + " " + Ques.Option3;
            }
            else
            {
                result = result + " " + Ques.Option4;
            }

            //        if(Answer==result)
            //        {
            //            score = score +1;
            //            return "you are correct";
            //        }
            //        else
            //        {
            //            return "YOU ARE WRONG";
            //        }
            return result;
        }
    
        // GET: /TestHistory/Details/5

        public ActionResult Details(int id = 0)
        {
            TestHistory testhistory = db.TestHistorys.Find(id);
            if (testhistory == null)
            {
                return HttpNotFound();
            }
            return View(testhistory);
        }

        //
        // GET: /TestHistory/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TestHistory/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TestHistory testhistory)
        {
            if (ModelState.IsValid)
            {
                db.TestHistorys.Add(testhistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testhistory);
        }

        //
        // GET: /TestHistory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TestHistory testhistory = db.TestHistorys.Find(id);
            if (testhistory == null)
            {
                return HttpNotFound();
            }
            return View(testhistory);
        }

        //
        // POST: /TestHistory/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TestHistory testhistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testhistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testhistory);
        }

        //
        // GET: /TestHistory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TestHistory testhistory = db.TestHistorys.Find(id);
            if (testhistory == null)
            {
                return HttpNotFound();
            }
            return View(testhistory);
        }

        //
        // POST: /TestHistory/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestHistory testhistory = db.TestHistorys.Find(id);
            db.TestHistorys.Remove(testhistory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}