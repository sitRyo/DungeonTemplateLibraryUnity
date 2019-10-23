using System;
using System.Runtime.InteropServices.WindowsRuntime;
using NUnit.Framework;

namespace DTL.Base {
    public class RogueLikeList {
        public int outsideWallId { get; set; }
        public int insideWallId { get; set; } 
        public int roomId { get; set; }
        public int entranceId { get; set; }
        public int wayId { get; set; }

        public RogueLikeList() { } // = default()

        public RogueLikeList(int wallId, int wayId) {
            this.outsideWallId = wallId;
            this.insideWallId = wallId;
            this.roomId = wayId;
            this.entranceId = wayId;
            this.wayId = wayId;
        }

        public RogueLikeList(int wallId, int roomId, int wayId) {
            this.outsideWallId = wallId;
            this.insideWallId = wallId;
            this.roomId = roomId;
            this.entranceId = roomId;
            this.wayId = wayId;
        }

        public RogueLikeList(int wallId, int roomId, int entranceId, int wayId) {
            this.outsideWallId = wallId;
            this.insideWallId = wallId;
            this.roomId = roomId;
            this.entranceId = entranceId;
            this.wayId = wayId;
        }

        public RogueLikeList(int outsideWallId, int insideWallId, int roomId, int entranceId, int wayId) {
            this.outsideWallId = outsideWallId;
            this.insideWallId = insideWallId;
            this.roomId = roomId;
            this.entranceId = entranceId;
            this.wayId = wayId;
        }

        public RogueLikeList DefaultRogueLikeList() {
            return new RogueLikeList(0, 1, 2, 3, 4);
        }
    }
}
