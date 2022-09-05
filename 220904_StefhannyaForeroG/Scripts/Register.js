function calculate() {
    const students = document.getElementById('Students_Number').value;
    let price = 200;
    const toga = document.getElementById('toga').checked;
    if (toga) {
        price = price + 20;
    }
    const total = students * price;
    document.getElementById('Price').value = total;
}