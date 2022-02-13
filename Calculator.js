function doCalculation(txtValue1_Id, ddlOperator_Id, txtValue2_Id, divResult_Id) {
    const value1 = document.getElementById(txtValue1_Id).value;
    const operator = document.getElementById(ddlOperator_Id).value;
    const value2 = document.getElementById(txtValue2_Id).value;
    const divResult = document.getElementById(divResult_Id);

    // validation
    if (value1 === "" || value2 === "") {
        divResult.innerHTML = "Please enter a number.";
        return;
    }

    var result = calculate(Number(value1), operator, Number(value2));
    divResult.innerHTML = result;
}

function calculate(value1, operator, value2) {
    switch (operator) {
        case "add": return value1 + value2;
        case "subract": return value1 - value2;
        case "multiply": return value1 * value2;
        case "divide":
            if (value2 === 0.00) {
                return "Cannot divide by zero.";
            }
            else {
                return value1 / value2;
            }
            break;
    }

    return "Operator not defined!";
}