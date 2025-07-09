function crearEmpleado() {
    const empleado = {
        Nombre: document.getElementById('Nombre').value,
        Apellido: document.getElementById('Apellido').value
    };

    fetch('/Empleado/Crear', {
        method: 'POST',
    headers: {
        'Content-Type': 'application/json'
        },
    body: JSON.stringify(empleado)
    })
    .then(response => response.json())
    .then(data => {
        if (data.success) {
        alert('Empleado creado correctamente.');
    window.location.href = '/Empleado/Index';
        } else {
        alert('Error al crear empleado.');
        }
    })
    .catch(error => console.error('Error:', error));
}
