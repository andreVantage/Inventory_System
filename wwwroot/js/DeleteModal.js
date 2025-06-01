
    const deleteModal = document.getElementById('deleteModal');
    deleteModal.addEventListener('show.bs.modal', function (event) {
        const button = event.relatedTarget;

    const productId = button.getAttribute('data-id');
    const productName = button.getAttribute('data-name');
    const productPrice = button.getAttribute('data-price');
    const productCategory = button.getAttribute('data-category');

    // Populate modal fields
    deleteModal.querySelector('#productId').value = productId;
    deleteModal.querySelector('#productName').textContent = productName;
    deleteModal.querySelector('#productPrice').textContent = productPrice;
    deleteModal.querySelector('#productCategory').textContent = productCategory;
    });

