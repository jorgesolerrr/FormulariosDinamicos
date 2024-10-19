
const API_URL = 'http://localhost:8080/api/Forms';





export async function GetFormData() {
    try {
        const response = await fetch(API_URL);
        if (!response.ok) {
            throw new Error('Network response was not ok ' + response.statusText);
        }
        const formData = await response.json();
        return formData;
    } catch (error) {
        console.error('There has been a problem with your fetch operation:', error);
        throw error;
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



 
