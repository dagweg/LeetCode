class Solution:
    def exclusiveTime(self, n: int, logs: List[str]) -> List[int]:
        result = [0] * n
        stack = []
        previous_timestamp = 0

        for id, typ, time in (log.split(":") for log in logs):
            id, time = int(id), int(time)
            if typ == "start":
                if stack:
                    result[stack[-1]] += time - previous_timestamp
                stack.append(id)
                previous_timestamp = time
            else:
                result[stack.pop()] += time - previous_timestamp + 1
                previous_timestamp = time + 1
        return result
