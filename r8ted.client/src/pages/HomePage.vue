<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="home-card p-5 bg-white rounded elevation-3">
      <!-- <img src="https://bcw.blob.core.windows.net/public/img/8600856373152463" alt="CodeWorks Logo"
        class="rounded-circle"> -->
      <h1 class="my-5 bg-dark text-white p-3 rounded text-center draggable-element" ref="draggableElement"
        @mousedown="onMouseDown">
        welcome to MVY
      </h1>
    </div>
  </div>

  <!-- <div id="draggable-element">Drag me!</div> -->
</template>

<script>
import interact from 'interactjs';

export default {
  mounted() {
    interact(this.$refs.draggableElement)
      .draggable({
        listeners: {
          move: this.onDragMove
        }
      });
  },
  methods: {
    onMouseDown(event) {
      // Prevent native dragging behavior
      event.preventDefault();
    },
    onDragMove(event) {
      const target = event.target;
      const x = (parseFloat(target.getAttribute('data-x')) || 0) + event.dx;
      const y = (parseFloat(target.getAttribute('data-y')) || 0) + event.dy;

      target.style.transform = `translate(${x}px, ${y}px)`;
      target.setAttribute('data-x', x);
      target.setAttribute('data-y', y);
    }
  }
};
</script>
  
<style scoped>
.draggable-element {
  width: 450px;
  height: 200px;
  background-color: #f2f2f2;
  border: 1px solid #ccc;
  cursor: move;
}
</style>