﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobiFlight.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobiFlight.Base.Tests
{
    [TestClass()]
    public class SerialNumberTests
    {
        [TestMethod()]
        public void ExtractSerialTest()
        {
            var serial = "GMA345/ SN-b44-4c5";
            var result = SerialNumber.ExtractSerial(serial);
            Assert.IsNotNull(result);
            Assert.AreEqual("SN-b44-4c5", result);

            serial = "Bravo Throttle Quadrant / JS-b0875190-3b89-11ed-8007-444553540000";
            result = SerialNumber.ExtractSerial(serial);
            Assert.IsNotNull(result);
            Assert.AreEqual("JS-b0875190-3b89-11ed-8007-444553540000", result);

            serial = "Arcaze/ 000393600000";
            result = SerialNumber.ExtractSerial(serial);
            Assert.IsNotNull(result);
            Assert.AreEqual("000393600000", result);
        }

        [TestMethod()]
        public void ExtractDeviceNameTest()
        {
            var serial = "GMA345/ SN-b44-4c5";
            var result = SerialNumber.ExtractDeviceName(serial);
            Assert.IsNotNull(result);
            Assert.AreEqual("GMA345", result);

            serial = "Bravo Throttle Quadrant / JS-b0875190-3b89-11ed-8007-444553540000";
            result = SerialNumber.ExtractDeviceName(serial);
            Assert.IsNotNull(result);
            Assert.AreEqual("Bravo Throttle Quadrant", result);

            serial = "Arcaze v5.36/ 000393600000";
            result = SerialNumber.ExtractDeviceName(serial);
            Assert.IsNotNull(result);
            Assert.AreEqual("Arcaze v5.36", result);
        }

        [TestMethod()]
        public void IsMobiFlightSerialTest()
        {
            var serial = "GMA345/ SN-b44-4c5";
            var result = SerialNumber.IsMobiFlightSerial(SerialNumber.ExtractSerial(serial));
            Assert.AreEqual(true, result);

            serial = "Bravo Throttle Quadrant / JS-b0875190-3b89-11ed-8007-444553540000";
            result = SerialNumber.IsMobiFlightSerial(SerialNumber.ExtractSerial(serial));
            Assert.AreEqual(false, result);

            serial = "Arcaze v5.36/ 000393600000";
            result = SerialNumber.IsMobiFlightSerial(SerialNumber.ExtractSerial(serial));
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void IsJoystickSerialTest()
        {
            var serial = "GMA345/ SN-b44-4c5";
            var result = SerialNumber.IsJoystickSerial(SerialNumber.ExtractSerial(serial));
            Assert.AreEqual(false, result);

            serial = "Bravo Throttle Quadrant / JS-b0875190-3b89-11ed-8007-444553540000";
            result = SerialNumber.IsJoystickSerial(SerialNumber.ExtractSerial(serial));
            Assert.AreEqual(true, result);

            serial = "Arcaze v5.36/ 000393600000";
            result = SerialNumber.IsJoystickSerial(SerialNumber.ExtractSerial(serial));
            Assert.AreEqual(false, result);
        }
    }
}