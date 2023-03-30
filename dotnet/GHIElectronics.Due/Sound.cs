using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GHIElectronics.DUE {


    public partial class DUEController {
        public class SoundController {


            SerialInterface serialPort;
            public SoundController(SerialInterface serialPort) => this.serialPort = serialPort;

            public int MaxFrequency { get; } = 1000000;
            public int MinFrequency { get; } = 16;

            public bool Play(int frequency, long duration_ms, int volume) {
                if (frequency < this.MinFrequency || frequency > this.MaxFrequency) {
                    throw new Exception("Frequency must be in range 16Hz..1000000Hz");
                }

                if (duration_ms > 99999999) {
                    throw new Exception("duration_ms must be in range 0..99999999");
                }

                if (volume < 0 || volume > 100) {
                    throw new Exception("volume must be in range 0..100");
                }


                //var cmd = "F " + frequency.ToString() + (duration_ms > 0 ? " " + duration_ms.ToString() : "");
                var cmd = string.Format("sound({0},{1},{2})", frequency.ToString(), duration_ms.ToString(), volume.ToString());


                this.serialPort.WriteCommand(cmd);

                var res = this.serialPort.ReadRespone();

                return res.success;

            }

            public bool Stop() {
                var frequency = 0;
                var duration_ms = 0;
                var dutycyle = 0;

                var cmd = string.Format("sound({0},{1},{2})", frequency.ToString(), duration_ms.ToString(), dutycyle.ToString());


                this.serialPort.WriteCommand(cmd);

                var res = this.serialPort.ReadRespone();

                return res.success;

            }
        }
    }
}
