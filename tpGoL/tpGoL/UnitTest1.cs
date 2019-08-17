using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tpGoL
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
           

        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic	here
            //
            caGOLeamaya.clGoL objGol = new caGOLeamaya.clGoL();
            string expected = objGol.Hello();
            string result = "Hello";
            Assert.AreEqual(expected, result);

        }


        //[TestMethod]
        //public void TestMethod2()
        //{
        //    //
        //    // TODO: Add test logic	here
        //    //
        //    caGOLeamaya.clGoL objGol = new caGOLeamaya.clGoL();
        //    string expected = objGol.Hello();
        //    string result = "Hello1";
        //    Assert.AreEqual(expected, result);

        //}

        [TestMethod]
        public void TestGrillaVacia()
        {
            //
            // TODO: Add test logic	here
            //
            caGOLeamaya.clGoL objGol = new caGOLeamaya.clGoL(10,10);
            string tabla = objGol.imprimir();
            //Assert.Inconclusive(tabla.ToString());

            int expected = 0;
            int result = objGol.obtenerValor(1,1);
            Assert.AreEqual(expected, result);                       

        }

        //RULE1: Any Live cell with fewer than two live neighbours DIES, as if caused by under-population.
        [TestMethod]
        public void TestEstaVivaConMenosDeDosVecinosVivos()
        {
            caGOLeamaya.clGoL objGol = new caGOLeamaya.clGoL(10, 10);
            objGol.ponerCeldaViva(3, 3);
            objGol.ponerCeldaViva(3, 4);

            string tabla1 = objGol.imprimir();
            //Assert.Inconclusive(tabla1.ToString());
            objGol.iterar();
            string tabla2 = objGol.imprimir();

            int expected = objGol.muerto;
            int result = objGol.obtenerValor(3, 3);
            //Assert.AreEqual(expected, result);

            int expected2 = objGol.muerto;
            int result2 = objGol.obtenerValor(3, 4);
            Assert.AreEqual(expected + expected2, result + result2);
        }

        //[TestMethod]
        //public void TestEstaVivaConMenosDeDosVecinosVivos2()
        //{
        //    caGOLeamaya.clGoL objGol = new caGOLeamaya.clGoL(10, 10);
        //    objGol.ponerCeldaViva(3, 3);
        //    objGol.ponerCeldaViva(3, 4);
        //    objGol.ponerCeldaViva(3, 5);

        //    string tabla1 = objGol.imprimir();
        //    //Assert.Inconclusive(tabla1.ToString());
        //    objGol.iterar();
        //    string tabla2 = objGol.imprimir();

        //    int expected = objGol.muerto;
        //    int result = objGol.obtenerValor(3, 3);
        //    //Assert.AreEqual(expected, result);

        //    int expected2 = objGol.muerto;
        //    int result2 = objGol.obtenerValor(3, 4);

        //    int expected3 = objGol.muerto;
        //    int result3 = objGol.obtenerValor(3, 5);

        //    Assert.AreEqual(expected + expected2 + expected3, result + result2 + result3);
        //}

        // RULE2:Any Live cell with two or three live neighbours LIVES, on the next generation.
        [TestMethod]
        public void TestEstaVivaConDosOrTresVecinosVivos()
        {
            caGOLeamaya.clGoL objGol = new caGOLeamaya.clGoL(10, 10);
            objGol.ponerCeldaViva(3, 3);
            objGol.ponerCeldaViva(3, 4);

            objGol.ponerCeldaViva(5, 2);
            objGol.ponerCeldaViva(5, 3);
            objGol.ponerCeldaViva(6, 2);
            objGol.ponerCeldaViva(6, 3);

            objGol.ponerCeldaViva(7, 7);
            objGol.ponerCeldaViva(7, 8);
            objGol.ponerCeldaViva(8, 7);

            string tabla1 = objGol.imprimir();
            //Assert.Inconclusive(tabla1.ToString());
            objGol.iterar();
            string tabla2 = objGol.imprimir();

            int expected = objGol.vivo;
            int result = objGol.obtenerValor(7, 7);
            //Assert.AreEqual(expected, result);

            int expected2 = objGol.vivo;
            int result2 = objGol.obtenerValor(7, 8);

            int expected3 = objGol.vivo;
            int result3 = objGol.obtenerValor(8, 7);

            Assert.AreEqual(expected + expected2 + expected3, result + result2 + result3);
        }


        [TestMethod]
        public void TestEstaVivaConMasDeVecinosVivos()
        {
            caGOLeamaya.clGoL objGol = new caGOLeamaya.clGoL(10, 10);
            objGol.ponerCeldaViva(3, 3);
            objGol.ponerCeldaViva(3, 4);

            objGol.ponerCeldaViva(5, 2);
            objGol.ponerCeldaViva(5, 3);
            objGol.ponerCeldaViva(6, 2);
            objGol.ponerCeldaViva(6, 3);
            objGol.ponerCeldaViva(7, 2);
            objGol.ponerCeldaViva(7, 3);

            objGol.ponerCeldaViva(7, 7);
            objGol.ponerCeldaViva(7, 8);
            objGol.ponerCeldaViva(8, 7);
            objGol.ponerCeldaViva(9, 7);
            objGol.ponerCeldaViva(9, 8);

            string tabla1 = objGol.imprimir();
            //Assert.Inconclusive(tabla1.ToString());
            objGol.iterar();
            string tabla2 = objGol.imprimir();

            int expected = objGol.vivo;
            int result = objGol.obtenerValor(5, 2);
            //Assert.AreEqual(expected, result);

            int expected2 = objGol.vivo;
            int result2 = objGol.obtenerValor(5, 3);

            int expected3 = objGol.muerto;
            int result3 = objGol.obtenerValor(6, 2);

            int expected4 = objGol.muerto;
            int result4 = objGol.obtenerValor(6, 3);

            Assert.AreEqual(expected + expected2 + expected3 + expected4, result + result2 + result3 + result4);
        }


        [TestMethod]
        public void TestEstaMuertoConExactamenteTresVecinosVivos()
        {
            caGOLeamaya.clGoL objGol = new caGOLeamaya.clGoL(10, 10);
            objGol.ponerCeldaViva(3, 3);
            objGol.ponerCeldaViva(3, 4);

            objGol.ponerCeldaViva(5, 2);
            objGol.ponerCeldaViva(5, 3);
            objGol.ponerCeldaViva(6, 2);
            objGol.ponerCeldaViva(6, 3);
            objGol.ponerCeldaViva(7, 2);
            objGol.ponerCeldaViva(7, 3);

            objGol.ponerCeldaViva(7, 7);
            objGol.ponerCeldaViva(7, 8);
            objGol.ponerCeldaViva(8, 7);
            objGol.ponerCeldaViva(9, 7);
            objGol.ponerCeldaViva(9, 8);

            string tabla1 = objGol.imprimir();
            //Assert.Inconclusive(tabla1.ToString());
            objGol.iterar();
            string tabla2 = objGol.imprimir();

            int expected = objGol.muerto;
            int result = objGol.obtenerValor(3, 2);
            //Assert.AreEqual(expected, result);

            int expected2 = objGol.muerto;
            int result2 = objGol.obtenerValor(3, 3);

            int expected3 = objGol.muerto;
            int result3 = objGol.obtenerValor(3, 4);


            int expected4 = objGol.vivo;
            int result4 = objGol.obtenerValor(4, 2);
            //Assert.AreEqual(expected, result);

            int expected5 = objGol.muerto;
            int result5 = objGol.obtenerValor(4, 3);

            int expected6 = objGol.vivo;
            int result6 = objGol.obtenerValor(4, 4);


            int expected7 = objGol.vivo;
            int result7 = objGol.obtenerValor(5, 2);
            //Assert.AreEqual(expected, result);

            int expected8 = objGol.vivo;
            int result8 = objGol.obtenerValor(5, 3);

            int expected9 = objGol.muerto;
            int result9 = objGol.obtenerValor(5, 4);

            Assert.AreEqual(expected + expected2 + expected3 + expected4 + expected5 + expected6 + expected7 + expected8 + expected9, result + result2 + result3 + result4 + result5 + result6 + result7 + result8 + result9);
        }


    }
}
