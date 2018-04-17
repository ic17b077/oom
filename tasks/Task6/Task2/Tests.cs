using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task2
{
    [TestFixture]
    class Tests
    {
        [Test]
        public void RadiusReturnSameValueAfterInizialisation()
        {
            Circle c = new Circle(5);
            Assert.IsTrue(c.radius == 5);
        }
        [Test]
        public void UpdateRadiusSetsRadius()
        {
            Circle c = new Circle(5);
            c.UpdateRadius(10);
            Assert.IsTrue(c.radius == 10);
        }
        [Test]
        public void CannotCreateCircleWithNegativeRadius()
        {
            Assert.Catch(() => {
                Circle c = new Circle(-5);
            });
        }
        [Test]
        public void CannotUpdateCircleWithNegativeRadius()
        {
            Assert.Catch(() => {
                Circle c = new Circle(5);
                c.UpdateRadius(-10);
            });
        }
        [Test]
        public void SideReturnSameValueAfterInizialisation()
        {
            Square x = new Square(5);
            Assert.IsTrue(x.side == 5);
        }
        [Test]
        public void UpdateSideSetsSide()
        {
            Square x = new Square(5);
            x.UpdateSide(10);
            Assert.IsTrue(x.side == 10);
        }
        [Test]
        public void CannotCreateSquareWithNegativeSide()
        {
            Assert.Catch(() => {
                Square x = new Square(-5);
            });
        }
        [Test]
        public void CannotUpdateSquareWithNegativeSide()
        {
            Assert.Catch(() => {
                Square x = new Square(5);
                x.UpdateSide(-10);
            });
        }
    }
}
