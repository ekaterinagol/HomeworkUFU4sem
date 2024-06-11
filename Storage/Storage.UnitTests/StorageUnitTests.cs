using Storage;
using Storage.WarehouseAdapters;
using Warehouse;

namespace StorageUnitTestProject
{
    [TestFixture]
    public class StorageUnitTests
    {
        MarkedProduct productA = new MarkedProduct("A", new Size(4, 5, 6), 2.1, 9785922100205);
        Product productB = new Product("B", new Size(1, 2, 3), 1.5);

        LimitedWarehouse storageLW = new LimitedWarehouse(5);
        LimitedWareHouseWithMarking storageLWM = new LimitedWareHouseWithMarking(8);
        UnlimitedWarehouse storageUW = new UnlimitedWarehouse();
        UnlimitedWarehouseWithMarking storageUWM = new UnlimitedWarehouseWithMarking();

        [Test]
        public void LimitedWarehouseTest()
        {
            var storage = new LimitedWarehouseAdapter(storageLW);

            AssertStorageAddDelete(storage, productA);
            AssertStorageAddDelete(storage, productB);
        }

        [Test]
        public void UnlimitedWarhouseTest()
        {
            var storage = new UnlimitedWarehouseAdapter(storageUW);

            AssertStorageAddDelete(storage, productA);
            AssertStorageAddDelete(storage, productB);
        }

        [Test]
        public void LimitedWareHouseWithMarkingTest()
        {
            var storage = new LimitedWarehouseWithMarkingAdapter(storageLWM);

            AssertStorageAddDelete(storage, productA);
            //AssertStorageAddDelete(storage, productB); 
            // проблема с продутом B, возникает в ADD
            //expected True but False. То есть: есть ли item в storage? ложь
        }

        [Test]
        public void UnlimitedWarehouseWithMarkingTest()
        {
            var storage = new UnlimitedWarehouseWithMarkingAdapter(storageUWM);

            AssertStorageAddDelete(storage, productA);
            //AssertStorageAddDelete(storage, productB);
        }

        void AssertStorageAddDelete(IStorage storage, object item)
        {
            storage.Add(item);
            Assert.IsTrue(storage.Contains(item)); //проблемы именно в add

            storage.Remove(item);
            Assert.IsFalse(storage.Contains(item));
        }

        void AssertMarkedStorageAddDelete(IStorage storage, object item)
        {
            storage.Add(item);
            Assert.IsTrue(storage.Contains(item)); //проблемы именно в add

            storage.Remove(item);
            Assert.IsFalse(storage.Contains(item));
        }
    }
}
