﻿using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

namespace UnitTestProject1.Strings {

    [TestClass]
    public class StringTests {

        [TestMethod]
        public void ParseBoolean() {

            Assert.AreEqual(true, StringHelper.ParseBoolean("true"), "Check #1 failed");
            Assert.AreEqual(false, StringHelper.ParseBoolean("false"), "Check #2 failed");
            Assert.AreEqual(true, StringHelper.ParseBoolean("True"), "Check #3 failed");
            Assert.AreEqual(false, StringHelper.ParseBoolean("False"), "Check #4 failed");

            Assert.AreEqual(true, StringHelper.ParseBoolean("1"), "Check #5 failed");
            Assert.AreEqual(false, StringHelper.ParseBoolean("0"), "Check #6 failed");

            Assert.AreEqual(true, StringHelper.ParseBoolean("t"), "Check #7 failed");
            Assert.AreEqual(false, StringHelper.ParseBoolean("f"), "Check #8 failed");
            Assert.AreEqual(true, StringHelper.ParseBoolean("T"), "Check #9 failed");
            Assert.AreEqual(false, StringHelper.ParseBoolean("F"), "Check #10 failed");

            Assert.AreEqual(false, StringHelper.ParseBoolean(""));
            Assert.AreEqual(false, StringHelper.ParseBoolean(default(string)));
            Assert.AreEqual(false, StringHelper.ParseBoolean(default(object)));

            Assert.AreEqual(true, StringUtils.ParseBoolean("true"), "Check #1 failed");
            Assert.AreEqual(false, StringUtils.ParseBoolean("false"), "Check #2 failed");
            Assert.AreEqual(true, StringUtils.ParseBoolean("True"), "Check #3 failed");
            Assert.AreEqual(false, StringUtils.ParseBoolean("False"), "Check #4 failed");

            Assert.AreEqual(true, StringUtils.ParseBoolean("1"), "Check #5 failed");
            Assert.AreEqual(false, StringUtils.ParseBoolean("0"), "Check #6 failed");

            Assert.AreEqual(true, StringUtils.ParseBoolean("t"), "Check #7 failed");
            Assert.AreEqual(false, StringUtils.ParseBoolean("f"), "Check #8 failed");
            Assert.AreEqual(true, StringUtils.ParseBoolean("T"), "Check #9 failed");
            Assert.AreEqual(false, StringUtils.ParseBoolean("F"), "Check #10 failed");

            Assert.AreEqual(false, StringUtils.ParseBoolean(""));
            Assert.AreEqual(false, StringUtils.ParseBoolean(default(string)));
            Assert.AreEqual(false, StringUtils.ParseBoolean(default(object)));

        }

        [TestMethod]
        public void ParseInt32() {

            Assert.AreEqual(0, StringUtils.ParseInt32(null), "Check #1 failed");
            Assert.AreEqual(0, StringUtils.ParseInt32(""), "Check #2 failed");

            Assert.AreEqual(3, StringUtils.ParseInt32(null, 3), "Check #3 failed");
            Assert.AreEqual(4, StringUtils.ParseInt32("", 4), "Check #4 failed");

            Assert.AreEqual(1, StringUtils.ParseInt32("1"), "Check #5 failed");
            Assert.AreEqual(2, StringUtils.ParseInt32("2"), "Check #6 failed");
            Assert.AreEqual(1, StringUtils.ParseInt32(" 1 "), "Check #7 failed");

            Assert.AreEqual(0, default(string).ToInt32(), "Check #8 failed");
            Assert.AreEqual(0, "".ToInt32(), "Check #9 failed");

            Assert.AreEqual(3, default(string).ToInt32(3), "Check #10 failed");
            Assert.AreEqual(4, "".ToInt32(4), "Check #11 failed");

            Assert.AreEqual(1, "1".ToInt32(), "Check #12 failed");
            Assert.AreEqual(2, "2".ToInt32(), "Check #13 failed");
            Assert.AreEqual(1, " 1 ".ToInt32(), "Check #14 failed");

            Assert.AreEqual(Int32.MaxValue, StringUtils.ParseInt32("2147483647"), "Check #15 failed");
            Assert.AreEqual(0, StringUtils.ParseInt32("2147483648"), "Check #16 failed");

        }

        [TestMethod]
        public void ParseInt32Array() {

            Assert.AreEqual(0, StringUtils.ParseInt32Array(null).Length, "Check #1 failed");
            Assert.AreEqual(0, StringUtils.ParseInt32Array("").Length, "Check #2 failed");
            Assert.AreEqual(0, StringUtils.ParseInt32Array("a").Length, "Check #3 failed");
            Assert.AreEqual(0, StringUtils.ParseInt32Array("_").Length, "Check #4 failed");

            Assert.AreEqual(1, StringUtils.ParseInt32Array("42").Length, "Check #5 failed");
            Assert.AreEqual(42, StringUtils.ParseInt32Array("42")[0], "Check #6 failed");

            Assert.AreEqual(3, StringUtils.ParseInt32Array("1,2,3").Length, "Check #7 failed");
            Assert.AreEqual(1, StringUtils.ParseInt32Array("1,2,3")[0], "Check #8 failed");
            Assert.AreEqual(2, StringUtils.ParseInt32Array("1,2,3")[1], "Check #9 failed");
            Assert.AreEqual(3, StringUtils.ParseInt32Array("1,2,3")[2], "Check #10 failed");

            Assert.AreEqual(3, StringUtils.ParseInt32Array("1 2 3").Length, "Check #11 failed");
            Assert.AreEqual(1, StringUtils.ParseInt32Array("1 2 3")[0], "Check #12 failed");
            Assert.AreEqual(2, StringUtils.ParseInt32Array("1 2 3")[1], "Check #13 failed");
            Assert.AreEqual(3, StringUtils.ParseInt32Array("1 2 3")[2], "Check #14 failed");

            Assert.AreEqual(3, StringUtils.ParseInt32Array("1_2_3", '_').Length, "Check #15 failed");
            Assert.AreEqual(1, StringUtils.ParseInt32Array("1_2_3", '_')[0], "Check #16 failed");
            Assert.AreEqual(2, StringUtils.ParseInt32Array("1_2_3", '_')[1], "Check #17 failed");
            Assert.AreEqual(3, StringUtils.ParseInt32Array("1_2_3", '_')[2], "Check #18 failed");

        }

        [TestMethod]
        public void ParseInt64() {

            Assert.AreEqual(0, StringUtils.ParseInt64(null), "Check #1 failed");
            Assert.AreEqual(0, StringUtils.ParseInt64(""), "Check #2 failed");

            Assert.AreEqual(3, StringUtils.ParseInt64(null, 3), "Check #3 failed");
            Assert.AreEqual(4, StringUtils.ParseInt64("", 4), "Check #4 failed");

            Assert.AreEqual(1, StringUtils.ParseInt64("1"), "Check #5 failed");
            Assert.AreEqual(2, StringUtils.ParseInt64("2"), "Check #6 failed");
            Assert.AreEqual(1, StringUtils.ParseInt64(" 1 "), "Check #7 failed");

            Assert.AreEqual(0, default(string).ToInt64(), "Check #8 failed");
            Assert.AreEqual(0, "".ToInt64(), "Check #9 failed");

            Assert.AreEqual(3, default(string).ToInt64(3), "Check #10 failed");
            Assert.AreEqual(4, "".ToInt64(4), "Check #11 failed");

            Assert.AreEqual(1, "1".ToInt64(), "Check #12 failed");
            Assert.AreEqual(2, "2".ToInt64(), "Check #13 failed");
            Assert.AreEqual(1, " 1 ".ToInt64(), "Check #14 failed");

            Assert.AreEqual(Int64.MaxValue, StringUtils.ParseInt64("9223372036854775807"), "Check #15 failed");
            Assert.AreEqual(0, StringUtils.ParseInt64("9223372036854775808"), "Check #16 failed");

        }

        [TestMethod]
        public void ParseInt64Array() {

            Assert.AreEqual(0, StringUtils.ParseInt64Array(null).Length, "Check #1 failed");
            Assert.AreEqual(0, StringUtils.ParseInt64Array("").Length, "Check #2 failed");
            Assert.AreEqual(0, StringUtils.ParseInt64Array("a").Length, "Check #3 failed");
            Assert.AreEqual(0, StringUtils.ParseInt64Array("_").Length, "Check #4 failed");

            Assert.AreEqual(1, StringUtils.ParseInt64Array("42").Length, "Check #5 failed");
            Assert.AreEqual(42, StringUtils.ParseInt64Array("42")[0], "Check #6 failed");

            Assert.AreEqual(3, StringUtils.ParseInt64Array("1,2,3").Length, "Check #7 failed");
            Assert.AreEqual(1, StringUtils.ParseInt64Array("1,2,3")[0], "Check #8 failed");
            Assert.AreEqual(2, StringUtils.ParseInt64Array("1,2,3")[1], "Check #9 failed");
            Assert.AreEqual(3, StringUtils.ParseInt64Array("1,2,3")[2], "Check #10 failed");

            Assert.AreEqual(3, StringUtils.ParseInt64Array("1 2 3").Length, "Check #11 failed");
            Assert.AreEqual(1, StringUtils.ParseInt64Array("1 2 3")[0], "Check #12 failed");
            Assert.AreEqual(2, StringUtils.ParseInt64Array("1 2 3")[1], "Check #13 failed");
            Assert.AreEqual(3, StringUtils.ParseInt64Array("1 2 3")[2], "Check #14 failed");

            Assert.AreEqual(3, StringUtils.ParseInt64Array("1_2_3", '_').Length, "Check #15 failed");
            Assert.AreEqual(1, StringUtils.ParseInt64Array("1_2_3", '_')[0], "Check #16 failed");
            Assert.AreEqual(2, StringUtils.ParseInt64Array("1_2_3", '_')[1], "Check #17 failed");
            Assert.AreEqual(3, StringUtils.ParseInt64Array("1_2_3", '_')[2], "Check #18 failed");

        }

        [TestMethod]
        public void ToUnderscore() {

            var samples1 = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "HelloWorld", Expected = "hello_world" },
                new { Input = "helloWorld", Expected = "hello_world" },
                new { Input = "HELLO_WORLD", Expected = "hello_world" },
                new { Input = "HelloWorld", Expected = "hello_world" },
                new { Input = "Hello World", Expected = "hello_world" },
                new { Input = "Hello (World)", Expected = "hello_world" },
                new { Input = "Hello / World", Expected = "hello_world" },
                new { Input = "Hello % World", Expected = "hello_world" },
                new { Input = "      Hello World", Expected = "hello_world" },
                new { Input = "Hello World      ", Expected = "hello_world" },
                new { Input = "Hello      World", Expected = "hello_world" },
                new { Input = "______Hello World", Expected = "hello_world" },
                new { Input = "Hello World______", Expected = "hello_world" },
                new { Input = "Hello______World", Expected = "hello_world" },
                new { Input = "Rød grød med fløde", Expected = "rød_grød_med_fløde" },
                new { Input = "øv bøv", Expected = "øv_bøv" },
                new { Input = "Øv bøv", Expected = "øv_bøv" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "not_found" },
                new { Input = HttpStatusCode.OK, Expected = "ok" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "not_implemented" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringHelper.ToUnderscore(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToUnderscore(sample.Input));
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringHelper.ToUnderscore(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToUnderscore(sample.Input));
            }

        }

        [TestMethod]
        public void ToCamelCase() {

            var samples1 = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "hello_world", Expected = "helloWorld" },
                new { Input = "HELLO_WORLD", Expected = "helloWorld" },
                new { Input = "HelloWorld", Expected = "helloWorld" },
                new { Input = "Hello World", Expected = "helloWorld" },
                new { Input = "Hello (World)", Expected = "helloWorld" },
                new { Input = "Hello / World", Expected = "helloWorld" },
                new { Input = "Hello % World", Expected = "helloWorld" },
                new { Input = "      Hello World", Expected = "helloWorld" },
                new { Input = "Hello World      ", Expected = "helloWorld" },
                new { Input = "Hello      World", Expected = "helloWorld" },
                new { Input = "______Hello World", Expected = "helloWorld" },
                new { Input = "Hello World______", Expected = "helloWorld" },
                new { Input = "Hello______World", Expected = "helloWorld" },
                new { Input = "Rød grød med fløde", Expected = "rødGrødMedFløde" },
                new { Input = "øv bøv", Expected = "øvBøv" },
                new { Input = "Øv bøv", Expected = "øvBøv" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "notFound" },
                new { Input = HttpStatusCode.OK, Expected = "ok" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "notImplemented" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringHelper.ToCamelCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCamelCase(sample.Input));
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringHelper.ToCamelCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToCamelCase(sample.Input));
            }

        }

        [TestMethod]
        public void ToPascalCase() {

            var samples1 = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "hello_world", Expected = "HelloWorld" },
                new { Input = "HELLO_WORLD", Expected = "HelloWorld" },
                new { Input = "HelloWorld", Expected = "HelloWorld" },
                new { Input = "Hello World", Expected = "HelloWorld" },
                new { Input = "Hello (World)", Expected = "HelloWorld" },
                new { Input = "Hello / World", Expected = "HelloWorld" },
                new { Input = "Hello % World", Expected = "HelloWorld" },
                new { Input = "      Hello World", Expected = "HelloWorld" },
                new { Input = "Hello World      ", Expected = "HelloWorld" },
                new { Input = "Hello      World", Expected = "HelloWorld" },
                new { Input = "______Hello World", Expected = "HelloWorld" },
                new { Input = "Hello World______", Expected = "HelloWorld" },
                new { Input = "Hello______World", Expected = "HelloWorld" },
                new { Input = "Rød grød med fløde", Expected = "RødGrødMedFløde" },
                new { Input = "øv bøv", Expected = "ØvBøv" },
                new { Input = "Øv bøv", Expected = "ØvBøv" }
            };

            var samples2 = new[] {
                new { Input = HttpStatusCode.NotFound, Expected = "NotFound" },
                new { Input = HttpStatusCode.OK, Expected = "Ok" },
                new { Input = HttpStatusCode.NotImplemented, Expected = "NotImplemented" }
            };

            foreach (var sample in samples1) {
                Assert.AreEqual(sample.Expected, StringHelper.ToPascalCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToPascalCase(sample.Input));
            }

            foreach (var sample in samples2) {
                Assert.AreEqual(sample.Expected, StringHelper.ToPascalCase(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.ToPascalCase(sample.Input));
            }

        }

        [TestMethod]
        public void ToLower() {

            var samples = new[] {
                new { Input = HttpStatusCode.Accepted, Expected = "accepted" },
                new { Input = HttpStatusCode.InternalServerError, Expected = "internalservererror" },
                new { Input = HttpStatusCode.OK, Expected = "ok" },
                new { Input = HttpStatusCode.BadRequest, Expected = "badrequest" },
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, StringUtils.ToLower(sample.Input));
                Assert.AreEqual(sample.Expected, sample.Input.ToLower());
            }

        }
        
        [TestMethod]
        public void ToUpper() {

            var samples = new[] {
                new { Input = HttpStatusCode.Accepted, Expected = "ACCEPTED" },
                new { Input = HttpStatusCode.InternalServerError, Expected = "INTERNALSERVERERROR" },
                new { Input = HttpStatusCode.OK, Expected = "OK" },
                new { Input = HttpStatusCode.BadRequest, Expected = "BADREQUEST" },
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, StringUtils.ToUpper(sample.Input));
                Assert.AreEqual(sample.Expected, sample.Input.ToUpper());
            }

        }

        [TestMethod]
        public void FirstCharToUpper() {

            var samples = new[] {
                new { Input = default(string), Expected = "" },
                new { Input = "", Expected = "" },
                new { Input = "hello_world", Expected = "Hello_world" },
                new { Input = "HELLO_WORLD", Expected = "HELLO_WORLD" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, StringHelper.FirstCharToUpper(sample.Input));
                Assert.AreEqual(sample.Expected, StringUtils.FirstCharToUpper(sample.Input));
            }

        }

        [TestMethod]
        public void WordCount() {

            string[] samples = {
                "Bacon ipsum dolor amet cupim beef ribs bresaola ribeye kevin fatback bacon sirloin picanha meatball! Hamburger bacon pig shoulder? Flank strip steak shoulder, tri-tip ham hock tenderloin meatball alcatra andouille boudin pork doner turkey. Turkey andouille doner swine turducken brisket kielbasa picanha jerky meatball burgdoggen pork shoulder ribeye. Ground round ball tip tenderloin tongue beef hamburger meatball porchetta filet mignon ham hock shoulder burgdoggen pig andouille tail. Pork chop shank bacon, pastrami corned beef fatback kevin. Fatback leberkas pork kielbasa, pork chop burgdoggen picanha meatball brisket spare ribs beef ribs.\n\nTenderloin prosciutto kielbasa beef ribs turducken jowl. Ball tip leberkas capicola, frankfurter kevin bresaola swine turducken pancetta meatloaf. Beef ribs corned beef cupim venison alcatra. Bresaola jerky porchetta beef ribs meatball, ball tip cow sausage cupim kielbasa. Frankfurter sausage tail brisket tenderloin cupim ham hock ribeye sirloin. Frankfurter biltong beef turducken."
            };

            foreach (string sample in samples) {

                int count1 = StringUtils.WordCount(sample);
                int count2 = sample.Split(new[] { ' ', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;

                Assert.AreEqual(count1, count2);

            }

        }

        [TestMethod]
        public void HighlightKeywords() {

            var samples = new [] {
                new {
                    Input = "Bacon ipsum dolor amet cupim beef ribs bresaola ribeye kevin fatback bacon sirloin picanha meatball.",
                    Output = "<span class=\"highlighted\">Bacon</span> ipsum dolor amet cupim <span class=\"highlighted\">beef</span> ribs bresaola ribeye kevin fatback <span class=\"highlighted\">bacon</span> sirloin picanha meatball."
                }
            };

            foreach (var sample in samples) {

                Assert.AreEqual(sample.Output, StringUtils.HighlightKeywords(sample.Input, "highlighted", "bacon", "beef"));

            }

        }

        [TestMethod]
        public void StripHtml() {

            var samples = new[] {
                new { Input = "<p>Hello World</p>", Output = "Hello World" },
                new { Input = "Hello<br />World", Output = "HelloWorld" },
                new { Input = "<p>Hello World &amp; Goodbye World</p>", Output = "Hello World & Goodbye World" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Output, StringUtils.StripHtml(sample.Input));
            }

        }

        [TestMethod]
        public void StripHtmlIgnore() {

            var samples = new[] {
                new { Input = "<p>Hello <strong>World</strong></p>", Output = "Hello <strong>World</strong>", Ignore = new []{"strong"} },
                new { Input = "<ul><li><a href=\"#hest\"><strong>Hest</strong><br /></a></li></ul>", Output = "<a href=\"#hest\">Hest</a>", Ignore = new []{"a"} }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Output, StringUtils.StripHtml(sample.Input, sample.Ignore));
            }

        }

        [TestMethod]
        public void IsInt32() {

            Assert.AreEqual(false, StringUtils.IsInt32(""), "#1");
            Assert.AreEqual(false, StringUtils.IsInt32("a"), "#2");
            Assert.AreEqual(true, StringUtils.IsInt32("42"), "#3");
            Assert.AreEqual(true, StringUtils.IsInt32("1234"), "#4");
            Assert.AreEqual(false, StringUtils.IsInt32("a1234"), "#5");
            Assert.AreEqual(false, StringUtils.IsInt32("a1234a"), "#6");
            Assert.AreEqual(false, StringUtils.IsInt32("1234a"), "#7");
            Assert.AreEqual(false, StringUtils.IsInt32("$1234"), "#8");
            Assert.AreEqual(false, StringUtils.IsInt32("1234kr"), "#9");

            Assert.AreEqual(true, StringUtils.IsInt32(Int32.MinValue + ""), "#10");
            Assert.AreEqual(true, StringUtils.IsInt32(Int32.MaxValue + ""), "#11");

            Assert.AreEqual(false, StringUtils.IsInt32(Int64.MinValue + ""), "#12");
            Assert.AreEqual(false, StringUtils.IsInt32(Int64.MaxValue + ""), "#13");

        }

        [TestMethod]
        public void IsInt64() {

            Assert.AreEqual(false, StringUtils.IsInt64(""), "#1");
            Assert.AreEqual(false, StringUtils.IsInt64("a"), "#2");
            Assert.AreEqual(true, StringUtils.IsInt64("42"), "#3");
            Assert.AreEqual(true, StringUtils.IsInt64("1234"), "#4");
            Assert.AreEqual(false, StringUtils.IsInt64("a1234"), "#5");
            Assert.AreEqual(false, StringUtils.IsInt64("a1234a"), "#6");
            Assert.AreEqual(false, StringUtils.IsInt64("1234a"), "#7");
            Assert.AreEqual(false, StringUtils.IsInt64("$1234"), "#8");
            Assert.AreEqual(false, StringUtils.IsInt64("1234kr"), "#9");

            Assert.AreEqual(true, StringUtils.IsInt64(Int32.MinValue + ""), "#10");
            Assert.AreEqual(true, StringUtils.IsInt64(Int32.MaxValue + ""), "#11");

            Assert.AreEqual(true, StringUtils.IsInt64(Int64.MinValue + ""), "#12");
            Assert.AreEqual(true, StringUtils.IsInt64(Int64.MaxValue + ""), "#13");

        }

        [TestMethod]
        public void IsDouble() {

            Assert.AreEqual(false, StringUtils.IsDouble(""), "#1");
            Assert.AreEqual(false, StringUtils.IsDouble("a"), "#2");
            Assert.AreEqual(true, StringUtils.IsDouble("42"), "#3");
            Assert.AreEqual(true, StringUtils.IsDouble("1234"), "#4");
            Assert.AreEqual(false, StringUtils.IsDouble("a1234"), "#5");
            Assert.AreEqual(false, StringUtils.IsDouble("a1234a"), "#6");
            Assert.AreEqual(false, StringUtils.IsDouble("1234a"), "#7");
            Assert.AreEqual(false, StringUtils.IsDouble("$1234"), "#8");
            Assert.AreEqual(false, StringUtils.IsDouble("1234kr"), "#9");

            Assert.AreEqual(true, StringUtils.IsDouble(Int32.MinValue + ""), "#10");
            Assert.AreEqual(true, StringUtils.IsDouble(Int32.MaxValue + ""), "#11");

            Assert.AreEqual(true, StringUtils.IsDouble(Int64.MinValue + ""), "#12");
            Assert.AreEqual(true, StringUtils.IsDouble(Int64.MaxValue + ""), "#13");

            Assert.AreEqual(true, StringUtils.IsDouble("-3.14159265358979"), "#14");
            Assert.AreEqual(true, StringUtils.IsDouble("+3.14159265358979"), "#15");

        }

        [TestMethod]
        public void IsAlphanumeric() {

            Assert.AreEqual(false, StringUtils.IsAlphanumeric(""), "#1");
            Assert.AreEqual(true, StringUtils.IsAlphanumeric("dQw4w9WgXcQ"), "#2");
            Assert.AreEqual(true, StringUtils.IsAlphanumeric("aaa"), "#3");
            Assert.AreEqual(true, StringUtils.IsAlphanumeric("AAA"), "#4");
            Assert.AreEqual(true, StringUtils.IsAlphanumeric("123"), "#5");
            Assert.AreEqual(false, StringUtils.IsAlphanumeric("$123"), "#6");
            Assert.AreEqual(false, StringUtils.IsAlphanumeric("123.456"), "#7");

        }
        
    }

}