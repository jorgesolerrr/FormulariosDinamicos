
const API_URL = 'http://localhost:8080/api/form';





export async function GetForms() {
    try {
        const response = await fetch(API_URL);
        const data = await response.json();
        console.log(data);
        return data;
    } catch (error) {
        console.error('Error fetching forms:', error);
        return null;
    }
}

export async function PostFormData(data) {
    try {
        const response = await fetch(API_URL, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        if (!response.ok) {
            throw new Error('Network response was not ok ' + response.statusText);
        }
        const responseData = await response.json();
        return responseData;
    } catch (error) {
        console.error('There has been a problem with your fetch operation:', error);
        throw error;
    }
}

export async function GetForm(id) {
    try {
        const response = await fetch(`${API_URL}/${id}`);
        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Error fetching form:', error);
        return null;
    }
}


