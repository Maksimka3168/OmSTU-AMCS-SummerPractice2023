using SquareEquationLib;
using TechTalk.SpecFlow;
namespace XUnit.Tests
{
    [Binding]
    public class SearchRoots
    {
        private readonly ScenarioContext _context;
        private double a, b, c;
        private double[] result = new double[2];
        public SearchRoots(ScenarioContext context)
        {
            _context = context;
        }

        [When(@"вычисляются корни квадратного уравнения")]
        public void SearchRoot()
        {
            try
            {
                result = SquareEquation.Solve(a, b, c);
            }
            catch (ArgumentException ex){}
        }
        [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
        public void TwoRootOneMult(double root1, double root2)
        {
            double[] rightRoots = {root1, root2};
            Array.Sort(rightRoots);
            Array.Sort(result);
            Assert.Equal(rightRoots, result);
        }

        [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
         public void OneRootTwoMult(double root1)
         {
            double[] rightRoots = {root1};
            Assert.Equal(rightRoots, result);
         }

         [Then(@"множество корней квадратного уравнения пустое")]
         public void SetRootsNull()
         {
            double[] rightRoots = {};
            Assert.Equal(rightRoots, result);
         }


        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
         public void NormalСoefficients(double root1, double root2, double root3 )
         {
             a = root1;
             b = root2;
             c = root3;
         }

         [Given(@"Квадратное уравнение с коэффициентами \(NaN, (.*), (.*)\)")]
         public void EquationHaveNotNumberA(double root1, double root2)
         {
             a = double.NaN;
             b = root1;
             c = root2;
         }

         [Given(@"Квадратное уравнение с коэффициентами \((.*), NaN, (.*)\)")]
         public void EquationHaveNotNumberB(double root1, double root2)
         {
             a = root1;
             b = double.NaN;
             c = root2;
         }

         [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), NaN\)")]
         public void EquationHaveNotNumberC(double root1, double root2)
         {
             a = root1;
             b = root2;
             c = double.NaN;
         }

         [Given(@"Квадратное уравнение с коэффициентами \(Double\.NegativeInfinity, (.*), (.*)\)")]
         public void EquationHaveNegInfA(int root1, int root2)
         {
             a = double.NegativeInfinity;
             b = root1;
             c = root2;
         }

         [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.NegativeInfinity, (.*)\)")]
         public void EquationHaveNegInfB(int root1, int root2)
         {
             a = root1;
             b = double.NegativeInfinity;
             c = root2;
         }

         [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.NegativeInfinity\)")]
         public void EquationHaveNegInfC(int root1, int root2)
         {
             a = root1;
             b = root2;
             c = double.NegativeInfinity;
         }

         [Given(@"Квадратное уравнение с коэффициентами \(Double\.PositiveInfinity, (.*), (.*)\)")]
         public void EquationHavePosInfA(int root1, int root2)
         {
             a = double.PositiveInfinity;
             b = root1;
             c = root2;
         }
         
         [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.PositiveInfinity, (.*)\)")]
         public void EquationHavePosInfB(int root1, int root2)
         {
             a = root1;
             b = double.PositiveInfinity;
             c = root2;
         }

         [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.PositiveInfinity\)")]
         public void EquationHavePosInfC(int root1, int root2)
         {
             a = root1;
             b = root2;
             c = double.PositiveInfinity;
         }

         [Then(@"выбрасывается исключение ArgumentException")]
         public void ThrownOutArgumentException()
         {
            try
            {
                var result = SquareEquation.Solve(a,b,c);
            }
            catch (Exception error)
            {
                Assert.Equal(error.GetType(), new ArgumentException().GetType());
            }
         }
    }
}