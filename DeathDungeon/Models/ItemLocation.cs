//using System;
//namespace DeathDungeon.Models
//{
//    public class ItemLocation
//    {
//        Item PrimaryFinger;
//        Item SecondaryFinger;
//        Item PrimaryHand;
//        Item SecondaryHand;
//        Item Head;
//        Item Chest;
//        Item Feet;
//        public ItemLocation()
//        {
//            PrimaryFinger = new Item((Location)1);
//            SecondaryFinger = new Item((Location)2);
//            PrimaryHand = new Item((Location)3);
//            SecondaryHand = new Item((Location)4);
//            Head = new Item((Location)5);
//            Chest = new Item((Location)6);
//            Feet = new Item((Location)7);
//        }
//        public void ReplaceSlot(Item item)
//        {
//            Location getloc = item.Location;
//            switch (getloc)
//            {
//                case (Location)0:
//                    {
//                        break;
//                    }
//                case (Location)1:
//                    {
//                        PrimaryFinger = item;
//                        break;
//                    }
//                case (Location)2:
//                    {
//                        SecondaryFinger = item;
//                        break;
//                    }
//                case (Location)3:
//                    {
//                        PrimaryHand = item;
//                        break;
//                    }
//                case (Location)4:
//                    {
//                        SecondaryHand = item;
//                        break;
//                    }
//                case (Location)5:
//                    {
//                        Head = item;
//                        break;
//                    }
//                case (Location)6:
//                    {
//                        Chest = item;
//                        break;
//                    }
//                case (Location)7:
//                    {
//                        Feet = item;
//                        break;
//                    }

//                default:
//                    {
//                        break;
//                    }
//            }
//        }
//        public void EmptySlot(Location slot)
//        {
//            //put items back into pot of items, then empty 
//            //addItemToPool();
//            switch (slot)
//            {
//                case (Location)0:
//                    {
//                        break;
//                    }
//                case (Location)1:
//                    {
//                        PrimaryFinger = new Item((Location)1);
//                        break;
//                    }
//                case (Location)2:
//                    {
//                        SecondaryFinger = new Item((Location)2);
//                        break;
//                    }
//                case (Location)3:
//                    {
//                        PrimaryHand = new Item((Location)3);
//                        break;
//                    }
//                case (Location)4:
//                    {
//                        SecondaryHand = new Item((Location)4);
//                        break;
//                    }
//                case (Location)5:
//                    {
//                        Head = new Item((Location)5);
//                        break;
//                    }
//                case (Location)6:
//                    {
//                        Chest = new Item((Location)6);
//                        break;
//                    }
//                case (Location)7:
//                    {
//                        Feet = new Item((Location)7);
//                        break;
//                    }

//                default:
//                    {
//                        break;
//                    }
//            }
//        }
//        public void EmptyAllSlots()
//        {
//            //additems to pool

//            //frees slots
//            PrimaryFinger = new Item((Location)1);
//            SecondaryFinger = new Item((Location)2);
//            PrimaryHand = new Item((Location)3);
//            SecondaryHand = new Item((Location)4);
//            Head = new Item((Location)5);
//            Chest = new Item((Location)6);
//            Feet = new Item((Location)7);
//        }
//    }
//}
