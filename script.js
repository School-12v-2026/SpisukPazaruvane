const shoppingList = [];

function addProduct() {
    const nameInput = document.getElementById("productName");
    const quantityInput = document.getElementById("productQuantity");

    const name = nameInput.value.trim();
    const quantity = quantityInput.value;

    if (name === "" || quantity === "") {
        alert("Моля, въведи име и количество!");
        return;
    }

    shoppingList.push({ name, quantity });

    nameInput.value = "";
    quantityInput.value = "";

    renderList();
}

function renderList() {
    const list = document.getElementById("shoppingList");
    list.innerHTML = "";

    shoppingList.forEach((product, index) => {
        const li = document.createElement("li");
        li.textContent = `${product.name} - ${product.quantity}`;

        const deleteBtn = document.createElement("button");
        deleteBtn.textContent = "❌";
        deleteBtn.className = "delete-btn";
        deleteBtn.onclick = () => removeProduct(index);

        li.appendChild(deleteBtn);
        list.appendChild(li);
    });
}

function removeProduct(index) {
    shoppingList.splice(index, 1);
    renderList();
}
